// (c) Copyright 2019-2021 HP Development Company, L.P.

using UnityEditor;
using NetMQ;

[InitializeOnLoad]
public static class ServiceUtils
{
    static ServiceUtils()
    {
        AssemblyReloadEvents.beforeAssemblyReload += OnBeforeAssemblyReload;
        EditorApplication.quitting += OnEditorQuitting;
    }

    public static void OnBeforeAssemblyReload()
    {
        NetMQConfig.Cleanup();
    }

    public static void OnEditorQuitting()
    {
        NetMQConfig.Cleanup();
    }
}