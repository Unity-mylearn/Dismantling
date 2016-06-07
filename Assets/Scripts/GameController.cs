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


public enum GameState{
	SHOW_MODEL = 0,
	UI_OPERATION = 1,
	GAME_OVER = 2
}

public class GameController : MonoBehaviour {


	private static GameState state;
	public static GameState STATE{
		get{ 
			return state;
		}
		set{ 
			state = value;
		}
	}

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

	void Awake(){
		state = GameState.SHOW_MODEL;
	}

	void Update(){
		if (currentGb == totalGb) {
			
		}
	}

}
