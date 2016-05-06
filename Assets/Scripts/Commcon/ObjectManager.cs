using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

	Dictionary<string,AssetBundle> adDict = new Dictionary<string, AssetBundle>();
	Dictionary<string,GameObject> objDict = new Dictionary<string, GameObject>();

	public GameObject GetPanel(string name){
		if (objDict.ContainsKey (name)) {
			return objDict [name];
		} else {
			return null;
		}
	}

	public void SetPanel(GameObject obj){
		GameObject canvas = GameObject.Find ("Canvas");
		RectTransform rect = obj.GetComponent<RectTransform> ();
		rect.parent = canvas.transform;
		rect.localScale = Vector3.one;
		rect.localPosition = Vector3.zero;
		rect.anchorMax = Vector2.one;
		rect.anchorMin = Vector2.zero;
		rect.sizeDelta = Vector2.zero;
	}
}
