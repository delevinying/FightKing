﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BadAgentMove : MonoBehaviour {
//	private int[,] mazeArray;
	private NavMeshAgent agent;
	public int startX;
	public int startY;
	private float tempTime;
	private float tempX = -100;
	private float tempY = -100;
	private bool isflag = false;
	public GameObject PopupDamage;
	// Use this for initialization
	void Start () {
		initState ();
	}
	
	// Update is called once per frame
	void Update () {
		doAgent ();
	}

//	void OnTriggerEnter(Collider collider){
//		if(collider.gameObject.tag=="player")
//		{
//			//克隆伤害弹出组件
//			Vector3 position  = collider.gameObject.transform.position;
//			GameObject mObject=(GameObject)Instantiate(PopupDamage,position,Quaternion.identity);
//			mObject.GetComponent<DamagePopup>().values=Random.Range(-200,-10);
//		}
//	}

//	void 

	private void initState(){
		agent = GetComponent<NavMeshAgent>();
		goPosition ();
	}

	private void doAgent(){
		if (tempX == this.gameObject.transform.position.x && tempY == this.gameObject.transform.position.y) {
			tempTime += Time.deltaTime;
//			Debug.Log ("   " + tempTime);
		}
		tempX = this.gameObject.transform.position.x;
		tempY = this.gameObject.transform.position.y;
		if (tempTime > 0.5) {
//			Debug.Log("isFlag   " + isflag);
			if (isflag) {
				goPosition ();
				isflag = false;
				tempTime = 0;
			} else {
				goPosition2 ();
				isflag = true;
				tempTime = 0;
			}
		}
	}

	private void goPosition(){
		int x = 11;
		int y = 11;
		Vector3 point = new Vector3 (x, 0, y);
		//转向  
		transform.LookAt(new Vector3(x, transform.position.y, y));  
		//设置寻路的目标点  
		agent.SetDestination(point);  
	}

	private void goPosition2(){
		int x = 5;
		int y = 15;
		Vector3 point = new Vector3 (x, 0, startY + y);
		//转向  
		transform.LookAt(new Vector3(x, transform.position.y, y));  
		//设置寻路的目标点  
		agent.SetDestination(point);  
	}
}
