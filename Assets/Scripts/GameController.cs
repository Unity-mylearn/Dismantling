using UnityEngine;
using System.Collections;


public enum ToolKind{
	FRONT_ROTATION = 0,
	BACK_ROTATION = 1,
	PRESSDOWN = 2,
	POPUP = 3,
	TENSCREW = 4,
	ONESCREW = 5,
	SPANNER = 6,
	BLOCK = 7,
}

public class GameController : MonoBehaviour {


	private static int totalGb;
	public static int TOTALGB{
		get{ 
			return totalGb;
		}
		set{ 
			totalGb = value;
		}
	}

	private static int currentGb;
	public static int CURRENTGB{
		get{
			return currentGb;
		}
		set{
			currentGb = value;
		}
	}

	void Update(){
		if (currentGb == totalGb) {
			
		}
	}

}
