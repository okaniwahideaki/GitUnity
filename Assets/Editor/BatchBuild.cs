using UnityEngine;
using UnityEditor;
using System.Collections;

public class BatchBuild {
	// WebPlayer Build.
	[UnityEditor.MenuItem("Tools/Build Project AllScene")]
	public static void BuildProjectAllSceneWebPlayer() {
		EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTarget.WebPlayer);
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			allScene[i] = scene.path;
			i++;
		}
		BuildPipeline.BuildPlayer (allScene,
		                          "WebPlayer",
		                          BuildTarget.WebPlayer,
		                          BuildOptions.None);

	}

	[UnityEditor.MenuItem("Tools/Build Project AllScene iOS")]
	public static void BuildProjectAllSceneiOS() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.iPhone );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}
		
		BuildOptions opt = BuildOptions.SymlinkLibraries |
			BuildOptions.AllowDebugging |
				BuildOptions.ConnectWithProfiler |
				BuildOptions.Development;


		//BUILD for Device.
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
		PlayerSettings.bundleIdentifier = "com.GitUnityiOS";
		PlayerSettings.statusBarHidden = true;
		string errorMsg_Device = BuildPipeline.BuildPlayer( 
		                                                   allScene,
		                                                   "iOSDevice",
		                                                   BuildTarget.iPhone,
		                                                   opt
		                                                   );
		
		if (string.IsNullOrEmpty(errorMsg_Device)){
			
		} else {
			//エラー処理適当に.	
		}
		
		
		//BUILD for Simulator
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.SimulatorSDK;
		//あとはDeviceビルドと同様に.
		PlayerSettings.bundleIdentifier = "com.GitUnityiOS";
		PlayerSettings.statusBarHidden = true;
		string errorMsg_Simulator = BuildPipeline.BuildPlayer( 
		                                                   allScene,
		                                                   "iOSSimulator",
		                                                   BuildTarget.iPhone,
		                                                   opt
		                                                   );
		if (string.IsNullOrEmpty(errorMsg_Simulator)){
			
		} else {
			//エラー処理適当に.	
		}
	}
	

}
