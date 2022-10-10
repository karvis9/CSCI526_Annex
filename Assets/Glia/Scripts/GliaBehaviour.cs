// (c) Copyright 2019-2021 HP Development Company, L.P.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HP.Omnicept;
using HP.Omnicept.Messaging;
using HP.Omnicept.Messaging.Messages;
using System.Threading.Tasks;

using NetMQ;
using System.Linq.Expressions;

namespace HP.Omnicept.Unity
{
    #region SerializableEvents

    [Serializable]
    public class HeartRateEvent : UnityEvent<HeartRate> { }
    [Serializable]
    public class HeartRateVariabilityEvent : UnityEvent<HeartRateVariability> { }
    [Serializable]
    public class PPGEvent : UnityEvent<PPGFrame> { }

    [Serializable]
    public class EyeTrackingEvent : UnityEvent<EyeTracking> { }

    [Serializable]
    public class VSyncEvent : UnityEvent<VSync> { }

    [Serializable]
    public class CognitiveLoadEvent : UnityEvent<CognitiveLoad> { }

    [Serializable]
    public class ConnectEvent : UnityEvent<GliaBehaviour> { }

    [Serializable]
    public class DisconnectEvent : UnityEvent<string> { }

    [Serializable]
    public class ConnectionFailureEvent : UnityEvent<Errors.ClientHandshakeError> { };

    [Serializable]
    public class CameraImageEvent : UnityEvent<CameraImage> { }

    [Serializable]
    public class DataVaultResultEvent : UnityEvent<DataVaultResult> { }

    [Serializable]
    public class IMUEvent : UnityEvent<IMUFrame> { }

    [Serializable]
    public class SubscriptionResultListEvent : UnityEvent<SubscriptionResultList> { }


    #endregion

    public class GliaBehaviour : MonoBehaviour
    {
        protected Glia m_gliaClient;
        protected GliaValueCache m_gliaValCache;
        protected Dictionary<uint, ITransportMessage> m_lastValues = new Dictionary<uint, ITransportMessage>();
        protected Task m_connectTask;
        protected bool m_isConnected;
        protected SubscriptionList m_subList = SubscriptionList.GetSubscriptionListToAll();

        public bool IsConnected { get { return m_isConnected; } }

        #region Events

        public HeartRateEvent OnHeartRate;
        public HeartRateVariabilityEvent OnHeartRateVariability;
        public PPGEvent OnPPGEvent;
        public EyeTrackingEvent OnEyeTracking;
        public VSyncEvent OnVSync;
        public CognitiveLoadEvent OnCognitiveLoad;
        public ConnectEvent OnConnect;
        public DisconnectEvent OnDisconnect;
        public ConnectionFailureEvent OnConnectionFailure;
        public CameraImageEvent OnCameraImage;
        public DataVaultResultEvent OnDataVaultResult;
        public IMUEvent OnIMUEvent;
        public SubscriptionResultListEvent OnSubscriptionResultListEvent;

        public static int gliaCount = 0;

        #endregion
        /// <summary>
        /// Sets the client subscription list
        /// </summary>
        /// <param name="subList">Subscription List</param>
        public void SetSubscriptions(SubscriptionList subList)
        {
                m_subList = subList;
                if(IsConnected)
                {
                    m_gliaClient.setSubscriptions(m_subList);
                }
        }
        /// <summary>
        /// Starts recording data to Data Vault
        /// </summary>
        public void DataVaultStartRecording()
        {
            DataVaultAction bva = new DataVaultAction(DataVaultAction.DataVaultActionType.Start_Recording);
            m_gliaClient.Connection.Send(bva);
        }
        /// <summary>
        /// Stops recording data to Data Vault
        /// </summary>
        public void DataVaultStopRecording()
        {
            DataVaultAction bva = new DataVaultAction(DataVaultAction.DataVaultActionType.Stop_Recording);
            m_gliaClient.Connection.Send(bva);
        }

        private bool EventHasTarget<T>(UnityEvent<T> e)
        {
            bool hasTarget = false;
            for (int i = 0; i < e.GetPersistentEventCount(); i++)
            {
                if (e.GetPersistentTarget(i) != null)
                {
                    hasTarget = true;
                    break;
                }
            }

            return hasTarget;
        }

        #region Message Handling

        bool ValidateConnection()
        { 
            if(!m_isConnected)
            {
                if (m_connectTask.Status == TaskStatus.Faulted)
                {
                    enabled = false;
                    m_connectTask.Exception.Handle((x) =>
                    {
                        if (x is Errors.ClientHandshakeError)
                        {
                            if (EventHasTarget(OnConnectionFailure))
                            {
                                OnConnectionFailure.Invoke((Errors.ClientHandshakeError)x);
                            }
                            else
                            {
                                Debug.LogError(x.Message);
                            }
                        }
                        else
                        {
                            Debug.LogError(x.Message);
                        }
                        return true;
                    });
                }
                else
                {
                    bool isConnected = m_connectTask.Status == TaskStatus.RanToCompletion;
                    if (isConnected)
                    {
                        m_gliaClient.setSubscriptions(m_subList);
                        m_isConnected = true;
                        OnConnect?.Invoke(this);
                    }
                }
            }

            return m_isConnected;
        }
        ITransportMessage RetrieveMessage()
        {
            ITransportMessage msg = null;
            if (m_gliaValCache != null)
            {
                try
                {
                    msg = m_gliaValCache.GetNext();
                }
                catch (HP.Omnicept.Errors.TransportError e)
                {
                    enabled = false;
                    if (EventHasTarget(OnDisconnect))
                    {
                        OnDisconnect.Invoke(e.Message);
                    }
                    else
                    {
                        Debug.LogError(e.Message);
                    }
                }
            }
            return msg;
        }
        void HandleMessage(ITransportMessage msg)
        {
            switch (msg.Header.MessageType)
            {
                //---------------
                case MessageTypes.ABI_MESSAGE_HEART_RATE:
                    if (OnHeartRate != null)
                    {
                        var heartRate = m_gliaClient.Connection.Build<HeartRate>(msg);
                        OnHeartRate.Invoke(heartRate);
                    }
                    break;
                case MessageTypes.ABI_MESSAGE_HEART_RATE_FRAME:
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_HEART_RATE_VARIABILITY:
                    if (OnHeartRateVariability != null)
                    {
                        var heartRateVariability = m_gliaClient.Connection.Build<HeartRateVariability>(msg);
                        OnHeartRateVariability.Invoke(heartRateVariability);
                    }
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_PPG:
                    break;
                case MessageTypes.ABI_MESSAGE_PPG_FRAME:
                    if (OnPPGEvent != null)
                    {
                        var ppgFrame = m_gliaClient.Connection.Build<PPGFrame>(msg);
                        OnPPGEvent.Invoke(ppgFrame);
                    }
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_EYE_TRACKING:
                    if (OnEyeTracking != null)
                    {
                        var eyeTracking = m_gliaClient.Connection.Build<EyeTracking>(msg);
                        OnEyeTracking.Invoke(eyeTracking);
                    }
                    break;
                case MessageTypes.ABI_MESSAGE_EYE_TRACKING_FRAME:
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_VSYNC:
                    if (OnVSync != null)
                    {
                        var vsync = m_gliaClient.Connection.Build<VSync>(msg);
                        OnVSync.Invoke(vsync);
                    }
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_SCENE_COLOR:
                    break;
                case MessageTypes.ABI_MESSAGE_SCENE_COLOR_FRAME:
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD:
                    if (OnCognitiveLoad != null)
                    {
                        var cload = m_gliaClient.Connection.Build<CognitiveLoad>(msg);
                        OnCognitiveLoad.Invoke(cload);
                    }
                    break;
                case MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD_INPUT_FEATURE:
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_BYTE_MESSAGE:
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_CAMERA_IMAGE:
                    if (OnCameraImage != null)
                    {
                        var cameraImage = m_gliaClient.Connection.Build<CameraImage>(msg);
                        OnCameraImage.Invoke(cameraImage);
                    }
                    break;
                case MessageTypes.ABI_MESSAGE_DATA_VAULT_RESULT:
                    if (OnDataVaultResult != null)
                    {
                        var dataVaultResult = m_gliaClient.Connection.Build<DataVaultResult>(msg);
                        OnDataVaultResult.Invoke(dataVaultResult);
                    }
                    break;

                //---------------
                case MessageTypes.ABI_MESSAGE_IMU:
                    break;
                case MessageTypes.ABI_MESSAGE_IMU_FRAME:
                    if (OnIMUEvent != null)
                    {
                        var imuFrame = m_gliaClient.Connection.Build<IMUFrame>(msg);
                        OnIMUEvent.Invoke(imuFrame);
                    }
                    break;
                case MessageTypes.ABI_MESSAGE_SUBSCRIPTION_RESULT_LIST:
                    if (OnSubscriptionResultListEvent != null)
                    {
                        var SRLmsg = m_gliaClient.Connection.Build<SubscriptionResultList>(msg);
                        OnSubscriptionResultListEvent.Invoke(SRLmsg);
                    }
                    break;

                default:
                    break;
            }

            m_lastValues[msg.Header.MessageType] = msg;
        }

        #endregion

        #region Unityism
        private void Start()
        {
            gliaCount++;
            DontDestroyOnLoad(gameObject);
            GliaSettings settings = Resources.Load<GliaSettings>("GliaSettings");

            if (settings == null)
            {
                //Use Defaults
                settings = ScriptableObject.CreateInstance<GliaSettings>();
            }

            SessionLicense sessionLicense = new SessionLicense(settings.ClientID, settings.AccessKey, settings.RequestedLicense, Application.isEditor);

            m_isConnected = false;
            Debug.Log("Connecting to service");
            m_connectTask = Task.Run( () =>
                {
                    m_gliaClient = new Glia("UnityClient", sessionLicense);
                    m_gliaValCache = new GliaValueCache(m_gliaClient.Connection);
                    Debug.Log("Connected To Omnicept Runtime");
                }
            );
        }

        void Update()
        {
            if(ValidateConnection())
            {
                ITransportMessage msg = RetrieveMessage();
                while (msg != null)
                {
                    HandleMessage(msg);
                    msg = RetrieveMessage();
                }
            }
        }

        private void OnDestroy()
        {
            gliaCount--;
            m_gliaValCache?.Stop();
            m_gliaClient?.Dispose();

            m_gliaValCache = null;
            m_gliaClient = null;

            if (gliaCount == 0){
                Glia.cleanupNetMQConfig(true);
            }
        }

        void OnEnable()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.wantsToQuit += WantsToQuit;
#else
            Application.wantsToQuit += WantsToQuit;
#endif
        }

        bool WantsToQuit()
        {
            OnDestroy();
            return true;
        }
        #endregion

        #region Generics For Message Handling
        private T BuildAndCopyMessage<T>(uint key) where T : IDomainType
        {
            ITransportMessage msg = null;

            if (m_lastValues.ContainsKey(key))
            {
                msg = m_lastValues[key];
            }

            if (msg == null)
            {
                return default(T);
            }

            T built = m_gliaClient.Connection.Build<T>(msg);
            return built;
        }

        private T GetLast<T>(uint messageType) where T : IDomainType
        {
            return BuildAndCopyMessage<T>(messageType);
        }
        #endregion

        #region LVC-like Functionality
        /// <summary>
        /// Get the last Heart Rate message
        /// </summary>
        /// <returns></returns>
        public HeartRate GetLastHeartRate()
        {
            return GetLast<HeartRate>(MessageTypes.ABI_MESSAGE_HEART_RATE);
        }
        /// <summary>
        /// Get the last Heart Rate Variability message
        /// </summary>
        /// <returns></returns>
        public HeartRateVariability GetLastHeartRateVariability()
        {
            return GetLast<HeartRateVariability>(MessageTypes.ABI_MESSAGE_HEART_RATE_VARIABILITY);
        }
        /// <summary>
        /// Get the last PPG Frame message
        /// </summary>
        /// <returns></returns>
        public PPGFrame GetLastPPGFrame()
        {
            return GetLast<PPGFrame>(MessageTypes.ABI_MESSAGE_PPG_FRAME);
        }
        /// <summary>
        /// Get the last Cognitive Load message
        /// </summary>
        /// <returns></returns>
        public CognitiveLoad GetLastCognitiveLoad()
        {
            return GetLast<CognitiveLoad>(MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD);
        }
        /// <summary>
        /// Get the last Eye Tracking message
        /// </summary>
        /// <returns></returns>
        public EyeTracking GetLastEyeTracking()
        {
            return GetLast<EyeTracking>(MessageTypes.ABI_MESSAGE_EYE_TRACKING);
        }
        /// <summary>
        /// Get the last VSync message
        /// </summary>
        /// <returns></returns>
        public VSync GetLastVsync()
        {
            return GetLast<VSync>(MessageTypes.ABI_MESSAGE_VSYNC);
        }
        /// <summary>
        /// Get the last IMU Frame message
        /// </summary>
        /// <returns></returns>
        public IMUFrame GetLastIMUFrame()
        {
            return GetLast<IMUFrame>(MessageTypes.ABI_MESSAGE_IMU_FRAME);
        }

        #endregion

    }

}
