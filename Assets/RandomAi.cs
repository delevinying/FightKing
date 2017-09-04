using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAi : MonoBehaviour {

	float stopTime;
	float moveTime;
	float vel_x,vel_y,vel_z;
	float maxPos_x = 55;//500;
	float maxPos_y = -2;//300;
	float minPos_x = 56;//-500;
	float minPos_y = -30;//-300;
	int curr_frame;
	int total_frame;
	float timeCounter1;
	float timeCounter2;
	// Use this for initialization
	void Start () {
		changePos ();
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter1 += Time.deltaTime;
		if (timeCounter1 < moveTime) {
			transform.Translate (vel_x, vel_y, 0, Space.Self);
		} else {
			timeCounter2 += Time.deltaTime;
			if (timeCounter2 > stopTime) {
				checkState ();
				timeCounter1 = 0;
				timeCounter2 = 0;
			}
		}
		checkState ();
	}

	void changePos(){
		stopTime = Random.Range (1, 5);
		moveTime = Random.Range (1, 20);
		vel_x = Random.Range (1, 10);
		vel_y = Random.Range (1, 10);
	}

	void checkState(){
		if (transform.localPosition.x > maxPos_x) {
			vel_x = -vel_x;
			transform.localPosition = new Vector3 (maxPos_x, transform.localPosition.y, 0);
		}
		if (transform.localPosition.x < minPos_x) {
			vel_x = -vel_x;
			transform.localPosition = new Vector3 (minPos_x, transform.localPosition.y, 0);
		}
		if (transform.localPosition.y > maxPos_y) {
			vel_y = -vel_y;
			transform.localPosition = new Vector3 (transform.localPosition.x, maxPos_y, 0);
		}
		if (transform.localPosition.y < minPos_y) {
			vel_y = -vel_y;
			transform.localPosition = new Vector3 (transform.localPosition.x, minPos_y, 0);
		}
	}
}
