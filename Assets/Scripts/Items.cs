using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

	[SerializeField]
	private ToolKind tool;

	public ToolKind TOOL{
		get{ 
			return tool;
		}
	}
	void ShowDialogAndOperationButton(object[] param){
		UIDialog.GETDIALOG.ShowDialog (param);
	}
}
