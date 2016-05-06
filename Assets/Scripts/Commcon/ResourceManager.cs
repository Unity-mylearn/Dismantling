using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ResourceManager : MonoBehaviour {
	static Dictionary<string,AssetBundle> m_bundleDict =
		new Dictionary<string, AssetBundle>();

//	public AssetBundle LoadBundle(string name){
		
//		if (m_bundleDict.ContainsKey (name) &&
//		    m_bundleDict [name] != null) {
//		
//			return m_bundleDict [name];
//		} else {
//			byte[] stream = null;
//			AssetBundle bundle = null;
//			string url = Util.DataPath + name.ToLower () + ".assetbundle";
//			stream = File.ReadAllBytes (url);
//
//			bundle = AssetBundle.LoadFromMemoryAsync (stream);
//			if (m_bundleDict.ContainsKey (name)) {
//				m_bundleDict [name] = bundle;
//			} else {
//				m_bundleDict.Add (name, bundle);
//			}
//			return bundle;
//		}
//	}



}
