using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor;

public class AutomaticVersionProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
#if UNITY_ANDROID
        //for google request
        PlayerSettings.Android.targetArchitectures |= AndroidArchitecture.ARM64;

        if (!report.summary.options.HasFlag(BuildOptions.Development)
            && EditorUtility.DisplayDialog("Bundle Version Code"
            , $"Current Bundle Version Code:{PlayerSettings.Android.bundleVersionCode}, ++?"
            , "Yes", "No"))
        {
            PlayerSettings.Android.bundleVersionCode++;
        }
#endif
    }
}
