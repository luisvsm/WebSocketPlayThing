#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Build {

    [MenuItem("Build/WebGL")]
	static void BuildWebGL ()
	{   
        PerformBuild(BuildTarget.WebGL);
	}

    [MenuItem("Build/iOS")]
    static void BuildiOS ()
	{   
        PerformBuild(BuildTarget.iOS);
	}

	static void PerformBuild (BuildTarget target)
	{
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Main.unity"};
        buildPlayerOptions.locationPathName = "builds/"+target.ToString();
        buildPlayerOptions.target = target;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        
        StartPostBuild(target);
	}

    private static void StartPostBuild (BuildTarget target){
        Process proc = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = "/bin/bash",
                Arguments = "Scripts/BuildScripts/postBuild.sh " + target.ToString(),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = Application.dataPath,
                WindowStyle = ProcessWindowStyle.Minimized
            }
        };

        proc.Start();
        while (!proc.StandardOutput.EndOfStream) {
            UnityEngine.Debug.Log(proc.StandardOutput.ReadLine());
            // do something with line
        }
        UnityEngine.Debug.Log("Finished running post build.");
    }
}
#endif