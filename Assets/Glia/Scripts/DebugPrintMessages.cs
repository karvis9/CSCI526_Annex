// (c) Copyright 2019-2021 HP Development Company, L.P.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HP.Omnicept;
using HP.Omnicept.Messaging;
using HP.Omnicept.Messaging.Messages;

public class DebugPrintMessages : MonoBehaviour
{
    [SerializeField]
    private bool showHeartRateMessages = true;
    [SerializeField]
    private bool showHeartRateVariabilityMessages = true;
    [SerializeField]
    private bool showPPGMessages = true;
    [SerializeField]
    private bool showCognitiveLoadMessages = true;
    [SerializeField]
    private bool showEyeTrackingMessages = true;
    [SerializeField]
    private bool showVsyncMessages = true;
    [SerializeField]
    private bool showCameraImageMessages = true;
    [SerializeField]
    private bool showCameraImageTexture = true;
    [SerializeField]
    private bool showIMUMessages = true;
    [SerializeField]
    private bool showSubscriptionResultListMessages = true;

    public Material cameraImageMat;
    private Texture2D cameraImageTex2D;

    public void Start()
    {
        cameraImageTex2D = new Texture2D(400, 400, TextureFormat.R8, false);
        if (cameraImageMat != null)
        {
            cameraImageMat.mainTexture = cameraImageTex2D;
        }
    }

    public void OnDestroy()
    {
        Destroy(cameraImageTex2D);
    }
    /// <summary>
    /// Logs the Heart Rate message to the Unity Console.
    /// </summary>
    /// <param name="hr">Heart Rate message</param>
    public void HeartRateHandler(HeartRate hr)
    {
        if (showHeartRateMessages && hr != null)
        {
            Debug.Log(hr);
        }
    }
    /// <summary>
    /// Logs the Heart Rate Variability message to the Unity Console.
    /// </summary>
    /// <param name="hrv">Heart Rate Variability message</param>
    public void HeartRateVariabilityHandler(HeartRateVariability hrv)
    {
        if (showHeartRateVariabilityMessages && hrv != null)
        {
            Debug.Log(hrv);
        }
    }
    /// <summary>
    /// Logs the PPG message to the Unity Console.
    /// </summary>
    /// <param name="ppg">PPG message</param>
    public void PPGFrameHandler(PPGFrame ppg)
    {
        if (showPPGMessages && ppg != null)
        {
            Debug.Log(ppg);
        }
    }
    /// <summary>
    /// Logs the Cognitive Load message to the Unity Console.
    /// </summary>
    /// <param name="cl">Cognitive Load message</param>
    public void CognitiveLoadHandler(CognitiveLoad cl)
    {
        if (showCognitiveLoadMessages && cl != null)
        {
            Debug.Log(cl);
        }
    }
    /// <summary>
    /// Logs the Eye Tracking message to the Unity Console.
    /// </summary>
    /// <param name="eyeTracking">Eye Tracking message</param>
    public void EyeTrackingHandler(EyeTracking eyeTracking)
    {
        if (showEyeTrackingMessages && eyeTracking != null)
        {
            Debug.Log(eyeTracking);
        }
    }
    /// <summary>
    /// Logs the VSync message to the Unity Console.
    /// </summary>
    /// <param name="vsync">VSync message</param>
    public void VSyncHandler(VSync vsync)
    {
        if (showVsyncMessages && vsync != null)
        {
            Debug.Log(vsync);
        }
    }
    /// <summary>
    /// Displays the camera image on the GameObject assigned material.
    /// </summary>
    /// <param name="cameraImage">Camera Imag messagee</param>
    public void CameraImageHandler(CameraImage cameraImage)
    {
        if (cameraImage != null)
        {
            if (showCameraImageMessages)
            {
                Debug.Log(cameraImage);
            }
            if (showCameraImageTexture && cameraImageMat != null && cameraImage.SensorInfo.Location == "Mouth")
            {
                // Load data into the texture and upload it to the GPU.
                cameraImageTex2D.LoadRawTextureData(cameraImage.ImageData);
                cameraImageTex2D.Apply();
            }
        }
    }
    /// <summary>
    /// Logs the IMU frame message to the Unity Console.
    /// </summary>
    /// <param name="imu">IMU frame message</param>
    public void IMUFrameHandler(IMUFrame imu)
    {
        if (showIMUMessages && imu != null)
        {
            Debug.Log(imu);
        }
    }
    /// <summary>
    /// Logs the disconnection message to the Unity Console.
    /// </summary>
    /// <param name="msg">Disconnect message</param>
    public void DisconnectHandler(string msg)
    {
        Debug.Log("Disconnected: " + msg);
    }
    /// <summary>
    /// Logs the connection failure message to the Unity Console.
    /// </summary>
    /// <param name="error">Client Handshake Error</param>
    public void ConnectionFailureHandler(HP.Omnicept.Errors.ClientHandshakeError error)
    {
        Debug.Log("Failed to connect: " + error);
    }
    /// <summary>
    /// Logs the connection failure message to the Unity Console.
    /// </summary>
    /// <param name="SRLmsg">Subscription List Result message</param>
    public void SubscriptionResultListHandler(SubscriptionResultList SRLmsg)
    {
        if (showSubscriptionResultListMessages && SRLmsg != null)
        {
            Debug.Log(SRLmsg);
        }
    }
}