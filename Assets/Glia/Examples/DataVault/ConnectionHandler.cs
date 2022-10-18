// (c) Copyright 2021 HP Development Company, L.P.

﻿using HP.Omnicept.Errors;
using HP.Omnicept.Messaging.Messages;
using HP.Omnicept.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HP.Omnicept.Unity.Examples.DataVault
{
    public class ConnectionHandler : MonoBehaviour
    {
        public Text LogText;
        private GliaBehaviour m_gliaBhv;
        private string m_latestSessID = "";

        private void Start()
        {
            Log("Connecting to runtime...");
        }

        private void Log(string message)
        {
            if (LogText)
            {
                LogText.text += message + "\n";
            }
            else
            {
                Debug.Log(message);
            }
        }

        public void ConnectHandler(GliaBehaviour gliaBhv)
        {
            Log("Connected to runtime");
            m_gliaBhv = gliaBhv;
        }

        public void DisconnectHandler(System.String str)
        {
            Log(str);
        }

        public void ConnectFailHandler(ClientHandshakeError err)
        {
            Log(err.Message);
        }

        public void StartDV()
        {
            if (!m_gliaBhv)
            {
                Log("Runtime not connected yet");
                return;
            }
            Log("Starting DataVault");
            m_gliaBhv.DataVaultStartRecording();
        }

        public void StopDV()
        {
            if (!m_gliaBhv)
            {
                Log("Runtime not connected yet");
                return;
            }
            Log("Stopping DataVault");
            m_gliaBhv.DataVaultStopRecording();
        }
        public void DataVaultHandler(DataVaultResult bvr)
        {
            if (bvr.m_error != DataVaultResult.DataVaultResultErrorType.Success_No_Error)
            {
                Log("DataVault error: " + bvr.m_error.ToString());
            }
            else
            {
                Log("DataVault result: " + bvr.m_result.ToString() + (bvr.m_sessionId == "" ? "" : " (SessionID: " + bvr.m_sessionId + ")"));
                if (bvr.m_sessionId != "") m_latestSessID = bvr.m_sessionId;
            }
        }
        public void CopySessID()
        {
            GUIUtility.systemCopyBuffer = m_latestSessID;
        }
    }
}
