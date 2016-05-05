using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	[SerializeField]
	private ToolKind tool;

	public static Tools _instanceTool;

	private static bool isSelect = false;
	public static bool SELECT{
		get{ 
			return isSelect;
		}
		set{ 
			isSelect = value;
		}
	}

	void Awake(){
		_instanceTool = this;
	}

	void OnClick(){
		UIDialog.GETDIALOG.SetCurrentTool (tool);
		SELECT = !SELECT;
	}

	void LaterUpdate(){
		if (isSelect)
			GetComponent<UISprite> ().spriteName = "btn_public2";
		else
			GetComponent<UISprite> ().spriteName = "btn_public3";
	}
}
