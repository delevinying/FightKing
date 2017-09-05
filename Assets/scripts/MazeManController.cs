using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManController : MonoBehaviour {

	int moveFlag;//移动方向 0静止 1上，2右 3下 4左
	private GameObject cherryObject;//目标对象
	int maxStopTime = 2;//最大停留时间
	float timeCounter1;
	float timeCounter2;
	float last_x = -100;
	float last_y = -100;
	float dec_x;
	float dec_y;
	float stopTimeCounter;

	void Start () {
		randomMoveState();
	}
		
	void Update () {
		//controlFun();
		if (moveFlag == 0) {//静止状态
			timeCounter1 += Time.deltaTime;
			if (timeCounter1 > maxStopTime) {//静止时间过久。重新随机运动状态
				randomMoveState ();
			}
		} else {
			if (timeCounter2 > 0.5 && checkMoveState ()) {
				last_x = transform.localPosition.x;
				last_y = transform.localPosition.y;
				timeCounter2 = 0;
				return;
			}
			if(moveFlag == 1){
				gameObject.transform.position += new Vector3 (0, -0.2f, 0);
			}else if(moveFlag == 2){
				gameObject.transform.position += new Vector3 (0.2f, 0, 0);
			}else if(moveFlag == 3){
				gameObject.transform.position += new Vector3 (0, 0.2f, 0);
			}else if(moveFlag == 4){
				gameObject.transform.position += new Vector3 (-0.2f, 0, 0);
			}
			timeCounter2 += Time.deltaTime;
		}
		last_x = transform.localPosition.x;
		last_y = transform.localPosition.y;

	}

	bool checkMoveState(){
		if (last_x != -100 || last_y != -100) {
			dec_x = Mathf.Abs (transform.localPosition.x - last_x);
			dec_y = Mathf.Abs (transform.localPosition.y - last_y);
			Debug.Log ("dec_x   " + dec_x);
			Debug.Log ("dec_y   " + dec_y);
			if (dec_x < 0.19 && dec_y < 0.19) {
//				stopTimeCounter += Time.deltaTime;
//				if (stopTimeCounter > maxStopTime) {
					randomMoveState ();
//				}
				return true;
			}
		}
		return false;
	}

	void randomMoveState(){
		moveFlag = Random.Range (0, 4);

		Debug.Log("moveFlag     "+moveFlag);
	}

	void controlFun(){
		if (Input.GetKey(KeyCode.W)) {
			gameObject.transform.position += new Vector3 (0, 0.1f, 0);
		}else if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.position += new Vector3 (-0.1f, 0, 0);
		}else if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.position += new Vector3 (0.1f, 0, 0);
		}else if (Input.GetKey(KeyCode.S)) {
			gameObject.transform.position += new Vector3 (0, -0.1f, 0);
		}
	}
}
