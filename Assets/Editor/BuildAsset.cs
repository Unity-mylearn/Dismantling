using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

public class BuildAsset {

	public static string platform = string.Empty;
	static List<string> paths = new List<string>();
	static List<string> files = new List<string>();


	static string AppDataPath{
		get{ 
			return Application.dataPath.ToLower ();
		}
	}

	static void Recursive(string path){
		string[] names = Directory.GetFiles (path);
		string[] dirs = Directory.GetDirectories (path);
		foreach (string filename in names) {
			string ext = Path.GetExtension (filename);
			if (ext.Equals (".meta"))
				continue;
			files.Add (filename.Replace ('\\', '/'));
		}

		foreach (string dir in dirs) {
			paths.Add (dir.Replace ('\\', '/'));
			Recursive (dir);
		}
	}

	static void UpdateProgress(int progress,int progressMax,string desc){
		string title = "Processing...[" + progress + "-" + progressMax + "]";
		float value = (float)progress / (float)progressMax;
		EditorUtility.DisplayProgressBar (title,desc,value);
	}

	public static void BuildAssetResoure(BuildTarget target,bool isSB){
		string dataPath = Util.DataPath;
		if (Directory.Exists (dataPath)) {
			Directory.Delete (dataPath, true);
		}
		//string assetfile = string.Empty;

		string resPath = AppDataPath + "/" + AppConst.AssetDirName + "/";
		if (!Directory.Exists (resPath)) {
			Directory.CreateDirectory (resPath);
		}
		BuildPipeline.BuildAssetBundles (resPath, BuildAssetBundleOptions.None, target);
		AssetDatabase.Refresh ();
	}
		
	[MenuItem("Package/BuildIphoneAsset",false,1)]
	public static void BuildIphoneResource(){
		BuildAssetResoure (BuildTarget.iOS, false);
	}

	[MenuItem("Package/BuildAndroidAsset",false,2)]
	public static void BuildAndroidResource(){
		BuildAssetResoure (BuildTarget.Android, false);
	}

	[MenuItem("Package/BuildWindowsAsset",false,3)]
	public static void BuildWindowsResource(){
		BuildAssetResoure (BuildTarget.StandaloneWindows, false);
	}


}
