using UnityEngine;
using System.Collections;

public class Tips : MonoBehaviour {

	[SerializeField]
	private UILabel message;

	private float time = 0;

	private static Tips _instance;
	public static Tips TIP{
		get{ 
			if (_instance == null) {
				
			}
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
		gameObject.SetActive (false);
	}

	public void ShowTips(string msg,float time){
		gameObject.SetActive (true);
		message.text = msg;
		this.time = time;
	}

	void Update(){
		if (time < 0 && gameObject.activeInHierarchy) {
			gameObject.SetActive (false);
		} else {
			time -= Time.deltaTime;
		}
	}
}
