using UnityEngine;
using System.Collections;

public class CameraCC : MonoBehaviour {

	[SerializeField]
	private Transform target;
	private float distance = 10.0f;

	private float xSpeed = 250.0f;
	private float ySpeed = 250.0f;

	private float yMinLimit = 30.0f;
	private float yMaxLimit = 80.0f;


	private float x = 0f;
	private float y = 0f;

	private Vector2 oldPosition1;
	private Vector2 oldPosition2;


	void Start(){
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;

	}

	void Update(){
		if (GameController.STATE != GameState.SHOW_MODEL)
			return;
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit _rayCast;
			Ray _ray;
			_ray = transform.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (_ray, out _rayCast, 1000)) {
				Debug.DrawLine (_ray.origin, _rayCast.point, Color.red, 2.0f);
				GameObject gb = _rayCast.collider.gameObject;
				object[] param = new object[4];
				string desc;
				Dismantling.DISMANTLING.GDDICT.TryGetValue (gb.name, out desc);
				string name = gb.name.ToString ();
				param [0] = name;
				param [1] = desc;
				param [2] = gb;
				param [3] = gb.GetComponent<Items> ().TOOL;
				GameController.STATE = GameState.UI_OPERATION;
				gb.SendMessage ("ShowDialogAndOperationButton",param);
			}
		}

		if (Input.touchCount == 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				x += Input.GetAxis ("Mouse X") * xSpeed * Time.deltaTime;
				y -= Input.GetAxis ("Mouse Y") * ySpeed * Time.deltaTime;
			}
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				RaycastHit _rayCast;
				Ray _ray;
				_ray = transform.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (_ray, out _rayCast, 1000)) {
					Debug.DrawLine (_ray.origin, _rayCast.point, Color.red, 2.0f);
					GameObject gb = _rayCast.collider.gameObject;
					object[] param = new object[4];
					string desc;
					Dismantling.DISMANTLING.GDDICT.TryGetValue (gb.name, out desc);
					string name = gb.name.ToString ();
					param [0] = name;
					param [1] = desc;
					param [2] = gb;
					param [3] = gb.GetComponent<Items> ().TOOL;
					GameController.STATE = GameState.UI_OPERATION;
					gb.SendMessage ("ShowDialogAndOperationButton",param);
				}
			}
		}
		if (Input.touchCount > 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved ||
			    Input.GetTouch (1).phase == TouchPhase.Moved) {

				Vector2 tempPosition1 = Input.GetTouch (0).position;
				Vector2 tempPosition2 = Input.GetTouch (1).position;

				if (isEnlarge (oldPosition1, oldPosition2, tempPosition1, tempPosition2)) {
					//放大系数超过3以后不允许继续放大
					//这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
					if (distance > 3) {
						distance -= 0.5f;
					}
				} else {
					//缩小洗漱返回18.5后不允许继续缩小
					//这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
					if (distance < 18.5f) {
						distance += 0.5f;
					}
				}
				//备份上一次触摸点的位置，用于对比
				oldPosition1 = tempPosition1;
				oldPosition2 = tempPosition2;
			}
		}
	}

	bool isEnlarge(Vector2 oP1,Vector2 oP2,Vector2 nP1 ,Vector2 nP2){
	
		//函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势
		var leng1 =Mathf.Sqrt((oP1.x-oP2.x)*(oP1.x-oP2.x)+(oP1.y-oP2.y)*(oP1.y-oP2.y));
		var leng2 =Mathf.Sqrt((nP1.x-nP2.x)*(nP1.x-nP2.x)+(nP1.y-nP2.y)*(nP1.y-nP2.y));
		if(leng1<leng2)
		{
			//放大手势
			return true;
		}else
		{
			//缩小手势
			return false;
		}
	}

	//Update方法一旦调用结束以后进入这里算出重置摄像机的位置
	void LateUpdate () {

		//target为我们绑定的箱子变量，缩放旋转的参照物
		if (target) {		

			//重置摄像机的位置
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			var rotation = Quaternion.Euler(y, x, 0);
			Vector3 temp = new Vector3 (0.0f, 0.0f, -distance);
			var position = rotation * temp + target.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	static float ClampAngle (float angle,float min, float max ) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
