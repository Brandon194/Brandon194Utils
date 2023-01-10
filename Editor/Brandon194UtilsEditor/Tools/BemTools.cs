using System.IO;
using UnityEngine;
using UnityEditor;
using Brandon194.Editor;

namespace Brandon194.Editor
{
    public static class BemTools
    {
        [MenuItem("Tools/Brandon194/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "Resources"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "AssetStore"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_Runtime"));
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "_Editor"));

            DefaultFolders.CreateDirectory("Resources", "Animation", "Audio", "Backgrounds", "Fonts", "Materials", "Models", "Palettes", "ParticleSystems", "Prefabs", "Screenshots", "ScriptableObjects", "Sprites", "textures");
            DefaultFolders.CreateDirectory("_Runtime", "Scripts");
            DefaultFolders.CreateDirectory("_Runtime/Scripts", "Core", "UI");
            DefaultFolders.CreateDirectory("_Runtime/Scripts/Core", "Interfaces");

            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Brandon194/Load 2D Manifest")]
        public static async void LoadNewManifest()
        {
            var url = PackageHandling.GetGistURL("5201666f7d8475310ef816b9668ce271");
            var contents = await PackageHandling.GetContents(url);
            PackageHandling.ReplacePackageFile(contents);
        }

        // Adds
        [MenuItem("Tools/Brandon194/Add Package/Analytics")]
        public static void GetAnalytics() => PackageHandling.InstallPackage("com.unity.analytics");
        [MenuItem("Tools/Brandon194/Add Package/CineMachine")]
        public static void GetCineMachine() => PackageHandling.InstallPackage("com.unity.cinemachine");
        [MenuItem("Tools/Brandon194/Add Package/InputSystem")]
        public static void GetInputSystem() => PackageHandling.InstallPackage("com.unity.inputsystem");
        [MenuItem("Tools/Brandon194/Add Package/PostProcessing")]
        public static void GetPostProcessing() => PackageHandling.InstallPackage("com.unity.postprocessing");
        [MenuItem("Tools/Brandon194/Add Package/Netcode")]
        public static void GetNetcodeForGameObjects() => PackageHandling.InstallPackage("com.unity.netcode.gameobjects");


        // Removes
        [MenuItem("Tools/Brandon194/Remove Package/Analytics")]
        public static void DelAnalytics() => PackageHandling.RemovePackage("com.unity.analytics");
        [MenuItem("Tools/Brandon194/Remove Package/CineMachine")]
        public static void DelCineMachine() => PackageHandling.RemovePackage("com.unity.cinemachine");
        [MenuItem("Tools/Brandon194/Remove Package/InputSystem")]
        public static void DelInputSystem() => PackageHandling.RemovePackage("com.unity.inputsystem");
        [MenuItem("Tools/Brandon194/Remove Package/PostProcessing")]
        public static void DelPostProcessing() => PackageHandling.RemovePackage("com.unity.postprocessing");
        [MenuItem("Tools/Brandon194/Remove Package/Netcode")]
        public static void DelNetcodeForGameObjects() => PackageHandling.InstallPackage("com.unity.netcode.gameobjects");
    }
}
