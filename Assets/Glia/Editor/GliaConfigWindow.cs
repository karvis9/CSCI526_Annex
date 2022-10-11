// (c) Copyright 2020-2021 HP Development Company, L.P.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HP.Omnicept.Unity
{
    public class GliaConfigWindow : EditorWindow
    {
        protected GliaSettings m_settings;
        protected Editor m_settingsEditor;

        [MenuItem("HP Omnicept/Configure")]
        public static void CreateWindow()
        {
            GliaConfigWindow window = (GliaConfigWindow)EditorWindow.GetWindow(typeof(GliaConfigWindow), true);
            window.minSize = new Vector2(625.0f, 175.0f);
        }

        private void OnEnable()
        {
            titleContent = new GUIContent("HP Omnicept");
            m_settings = Resources.Load("GliaSettings") as GliaSettings;

            if(m_settings == null)
            {
                m_settings = CreateInstance<GliaSettings>();
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                AssetDatabase.CreateAsset(m_settings, "Assets/Resources/GliaSettings.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

        private void OnDisable()
        {
            if(m_settingsEditor != null)
            {
                DestroyImmediate(m_settingsEditor);
            }
        }

        void OnGUI()
        {
            if (m_settingsEditor == null)
            {
                m_settingsEditor = Editor.CreateEditor(m_settings);
            }
            m_settingsEditor.OnInspectorGUI();
            
            if(GUILayout.Button("Ok"))
            {
               Close();
            }
        }
    }

    [CustomEditor(typeof(GliaSettings))]
    public class GliaSettingsEditor : Editor
    {
        string clientIDField = "";
        string accessKeyField = "";

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GliaSettings gliaSettings = (GliaSettings) target;

            clientIDField = EditorGUILayout.PasswordField(new GUIContent("Client ID", gliaSettings.ClientID), gliaSettings.ClientID);
            accessKeyField = EditorGUILayout.PasswordField(new GUIContent("Access Key", gliaSettings.AccessKey), gliaSettings.AccessKey);

            if (GUI.changed)
            {
                gliaSettings.ClientID = clientIDField.Trim();
                gliaSettings.AccessKey = accessKeyField.Trim();
                EditorUtility.SetDirty(target);
            }
        }
    }
}