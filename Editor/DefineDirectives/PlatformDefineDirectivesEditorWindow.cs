﻿using UnityEditor;
using UnityEngine;

namespace PumpEditor
{
    public class PlatformDefineDirectivesEditorWindow : EditorWindow
    {
        // Platform define directives from https://docs.unity3d.com/2019.3/Documentation/Manual/PlatformDependentCompilation.html
        private const string UNITY_EDITOR_DEFINE = "UNITY_EDITOR";
        private const string UNITY_EDITOR_WIN_DEFINE = "UNITY_EDITOR_WIN";
        private const string UNITY_EDITOR_OSX_DEFINE = "UNITY_EDITOR_OSX";
        private const string UNITY_EDITOR_LINUX_DEFINE = "UNITY_EDITOR_LINUX";
        private const string UNITY_STANDALONE_OSX_DEFINE = "UNITY_STANDALONE_OSX";
        private const string UNITY_STANDALONE_WIN_DEFINE = "UNITY_STANDALONE_WIN";
        private const string UNITY_STANDALONE_LINUX_DEFINE = "UNITY_STANDALONE_LINUX";
        private const string UNITY_STANDALONE_DEFINE = "UNITY_STANDALONE";
        private const string UNITY_WII_DEFINE = "UNITY_WII";
        private const string UNITY_IOS_DEFINE = "UNITY_IOS";
        private const string UNITY_IPHONE_DEFINE = "UNITY_IPHONE";
        private const string UNITY_ANDROID_DEFINE = "UNITY_ANDROID";
        private const string UNITY_PS4_DEFINE = "UNITY_PS4";
        private const string UNITY_XBOXONE_DEFINE = "UNITY_XBOXONE";
        private const string UNITY_LUMIN_DEFINE = "UNITY_LUMIN";
        private const string UNITY_TIZEN_DEFINE = "UNITY_TIZEN";
        private const string UNITY_TVOS_DEFINE = "UNITY_TVOS";
        private const string UNITY_WSA_DEFINE = "UNITY_WSA";
        private const string UNITY_WSA_10_0_DEFINE = "UNITY_WSA_10_0";
        private const string UNITY_WINRT_DEFINE = "UNITY_WINRT";
        private const string UNITY_WINRT_10_0_DEFINE = "UNITY_WINRT_10_0";
        private const string UNITY_WEBGL_DEFINE = "UNITY_WEBGL";
        private const string UNITY_FACEBOOK_DEFINE = "UNITY_FACEBOOK";
        private const string UNITY_ADS_DEFINE = "UNITY_ADS";
        private const string UNITY_ANALYTICS_DEFINE = "UNITY_ANALYTICS";
        private const string UNITY_ASSERTIONS_DEFINE = "UNITY_ASSERTIONS";
        private const string UNITY_64_DEFINE = "UNITY_64";

        private Vector2 scrollPos;

        [MenuItem("Window/Pump Editor/Platform Define Directives")]
        private static void ShowWindow()
        {
            var window = EditorWindow.GetWindow<PlatformDefineDirectivesEditorWindow>();
            var icon = EditorGUIUtility.Load("scriptableobject icon") as Texture2D;
            window.titleContent = new GUIContent("Platform Define Directives", icon);
            window.Show();
        }

        private static void DrawPlatformDefines()
        {
            DrawDefine(UNITY_EDITOR_DEFINE, PlatformDefines.UnityEditorDefined);
            DrawDefine(UNITY_EDITOR_WIN_DEFINE, PlatformDefines.UnityEditorWinDefined);
            DrawDefine(UNITY_EDITOR_OSX_DEFINE, PlatformDefines.UnityEditorOsxDefined);
            DrawDefine(UNITY_EDITOR_LINUX_DEFINE, PlatformDefines.UnityEditorLinuxDefined);
            DrawDefine(UNITY_STANDALONE_OSX_DEFINE, PlatformDefines.UnityStandaloneOsxDefined);
            DrawDefine(UNITY_STANDALONE_WIN_DEFINE, PlatformDefines.UnityStandaloneWinDefined);
            DrawDefine(UNITY_STANDALONE_LINUX_DEFINE, PlatformDefines.UnityStandaloneLinuxDefined);
            DrawDefine(UNITY_STANDALONE_DEFINE, PlatformDefines.UnityStandaloneDefined);
            DrawDefine(UNITY_WII_DEFINE, PlatformDefines.UnityWiiDefined);
            DrawDefine(UNITY_IOS_DEFINE, PlatformDefines.UnityIosDefined);
            DrawDefine(UNITY_IPHONE_DEFINE, PlatformDefines.UnityIphoneDefined);
            DrawDefine(UNITY_ANDROID_DEFINE, PlatformDefines.UnityAndroidDefined);
            DrawDefine(UNITY_PS4_DEFINE, PlatformDefines.UnityPs4Defined);
            DrawDefine(UNITY_XBOXONE_DEFINE, PlatformDefines.UnityXboxoneDefined);
            DrawDefine(UNITY_LUMIN_DEFINE, PlatformDefines.UnityLuminDefined);
            DrawDefine(UNITY_TIZEN_DEFINE, PlatformDefines.UnityTizenDefined);
            DrawDefine(UNITY_TVOS_DEFINE, PlatformDefines.UnityTvosDefined);
            DrawDefine(UNITY_WSA_DEFINE, PlatformDefines.UnityWsaDefined);
            DrawDefine(UNITY_WSA_10_0_DEFINE, PlatformDefines.UnityWsa10Defined);
            DrawDefine(UNITY_WINRT_DEFINE, PlatformDefines.UnityWinrtDefined);
            DrawDefine(UNITY_WINRT_10_0_DEFINE, PlatformDefines.UnityWinrt10Defined);
            DrawDefine(UNITY_WEBGL_DEFINE, PlatformDefines.UnityWebglDefined);
            DrawDefine(UNITY_FACEBOOK_DEFINE, PlatformDefines.UnityFacebookDefined);
            DrawDefine(UNITY_ADS_DEFINE, PlatformDefines.UnityAdsDefined);
            DrawDefine(UNITY_ANALYTICS_DEFINE, PlatformDefines.UnityAnalyticsDefined);
            DrawDefine(UNITY_ASSERTIONS_DEFINE, PlatformDefines.UnityAssertionsDefined);
            DrawDefine(UNITY_64_DEFINE, PlatformDefines.Unity64Defined);
        }

        private static void DrawDefine(string compilationSymbol, bool isDefined)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(compilationSymbol);
                EditorGUILayout.LabelField(isDefined ? "Set" : "Not Set");
            }
        }

        private void OnGUI()
        {
            using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPos))
            {
                scrollPos = scrollView.scrollPosition;
                DrawPlatformDefines();
            }
        }
    }
}
