using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dismantling : MonoBehaviour {

	private static Dismantling _instance;
	public static Dismantling DISMANTLING{
		get{ 
			if (_instance == null) {
				return null;
			}
			return _instance;
		}
	} 

	[SerializeField]
	private TextAsset info;

	private Dictionary<string,string> gbDict = new Dictionary<string, string>();
	public Dictionary<string,string> GDDICT{
		get{
			if (gbDict.Count == 0) {
				InitGbDict ();
			}
			return gbDict;
		}
	}

	void Awake(){
		_instance = this;
		InitGbDict ();
	}

	void InitGbDict(){
		string info_text = info.text;
		string[] str = info_text.Split ('\n');
		foreach (string temp in str) {
			string[] result = temp.Split ('|');
			gbDict.Add (result[0],result[1]);
			GameController.TOTALGB++;
		}

	}
}
