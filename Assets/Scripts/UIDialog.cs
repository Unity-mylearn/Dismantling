using UnityEngine;
using System.Collections;

public class UIDialog : MonoBehaviour {

	[SerializeField]
	private UILabel desc;
	[SerializeField]
	private UIButton back_button;
	[SerializeField]
	private UIButton dimant_button;
	[SerializeField]
	private UILabel currentTool;

	private ToolKind needTool;
	private ToolKind tool;

	private static UIDialog _instance;
	public static UIDialog GETDIALOG{
		get{ 
			if (_instance == null) {
			}
			return _instance;
		}
	}

	private int nextGb = -1;
	private GameObject clickGameobject = null;

	[SerializeField]
	private GameObject[] tools;

	void Awake(){
		_instance = this;
		EventDelegate backEvent = new EventDelegate (this, "CloseDialog");
		back_button.onClick.Add (backEvent);

		EventDelegate dimantEvent = new EventDelegate (this, "OnDimantClick");
		dimant_button.onClick.Add (dimantEvent);
		foreach (GameObject gb in tools) {
			
		}
		CloseDialog ();
	}

	public void ShowDialog(object[] param){
		gameObject.SetActive (true);
		desc.text = param[1].ToString();
		nextGb = int.Parse (param [0].ToString());
		clickGameobject = param [2] as GameObject;
		this.needTool = (ToolKind)param [3];
	}

	public void CloseDialog(){
		gameObject.SetActive (false);
		GameController.STATE = GameState.SHOW_MODEL;
	}

	public void OnBackClick(){
		CloseDialog ();
	}

	public void OnDimantClick(){
		if (GameController.CURRENTGB == nextGb) {
			if (tool == needTool) {
				GameController.CURRENTGB++;
				clickGameobject.SetActive (false);
				CloseDialog ();
			} else {
				Tips.TIP.ShowTips ("工具好像错了哦",1f);
			}
		} else {
			Tips.TIP.ShowTips ("顺序好像错了哦", 1f);
		}
	}

	public void SetCurrentTool(ToolKind tool){
		this.tool = tool;
		switch (tool) {
		case ToolKind.FRONT_ROTATION:
			currentTool.text = "FRONT_ROTATION";
			break;
		case ToolKind.BACK_ROTATION:
			currentTool.text = "BACK_ROTATION";
			break;
		case ToolKind.PRESSDOWN:
			currentTool.text = "PRESSDOWN";
			break;
		case ToolKind.POPUP:
			currentTool.text = "POPUP";
			break;
		case ToolKind.TENSCREW:
			currentTool.text = "TENSCREW";
			break;
		case ToolKind.ONESCREW:
			currentTool.text = "ONESCREW";
			break;
		case ToolKind.SPANNER:
			currentTool.text = "SPANNER";
			break;
		case ToolKind.BLOCK:
			currentTool.text = "BLOCK";
			break;
		}
	}
}
