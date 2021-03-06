﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CreateMaze : MonoBehaviour {

	public GameObject wallItem;//每块墙
	public GameObject bad;//NPC
	public int startX;
	public int startY;
	public int maxBad;//NPC的最大数量
	private int nowFoolr = 1;//所在塔层
	public int[,] mazeNum = null;
//	private MazeManager mazeManager;
	private NavMeshAgent agent;//玩家的agent

	public float range = 0.001f;//射击范围
	public float timeBetweenBullets = 0.15f;//发射子弹的间隔
	float effectsDisplayTime = 0.2f;//子弹消失的时间
	float timer;//计时器
	Ray shootRay; //定义射线
	RaycastHit shootHit;
	LineRenderer gunLine;
	int shootableMask;//定义接受射线的面，mask

	void Start () {
		initState ();
		initGunLine ();
	}
	
	// Update is called once per frame
	void Update () {
		doAngent ();
		doGunFun ();
	}

	private void initState(){
		this.mazeNum = MazeArray.getArray (this.nowFoolr - 1);//当前在第一层
		drawWall ();//开始绘制
//		mazeManager = MazeManager.GetInstance ();
		agent = GetComponent<NavMeshAgent>();
	}

	//初始化子弹射线
	private void initGunLine(){
		shootableMask = LayerMask.GetMask("Shootable");
		gunLine = GetComponent<LineRenderer>();
		gunLine.useWorldSpace = false;
		gunLine.SetWidth (0.2f, 0.2f);
	}

	private void doGunFun(){
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("timer,timeBetweenBullets:" + timer + "," + timeBetweenBullets);
			Shoot();
		}
		if (timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects();
		}
	}



	//绘制墙
	private void drawWall(){
		for (int x = 0; x < 30; x++)
		{
			for (int y = 0; y < 30; y++)
			{
				if (mazeNum [x, y] == 1) {
					Instantiate (wallItem, new Vector3 (startX + (x - 1), 0, startY + (y - 1)), Quaternion.identity);
				} else if (mazeNum [x, y] == 2) {
					Instantiate (bad, new Vector3 (startX + (x - 1), 0, startY + (y - 1)), Quaternion.identity);
				}
			}
		}
	}

	private void doAngent(){
		//鼠标左键点击  
		if (Input.GetMouseButtonDown(1))  
		{  
			if (agent.isStopped) {
			//	agent.Resume ();
			}
			//摄像机到点击位置的的射线  
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
			RaycastHit hit;  
			if (Physics.Raycast(ray, out hit))  
			{  
				//判断点击的是否地形  
				if (!hit.collider.name.Equals("Cube"))  
				{  
					return;  
				}
				//点击位置坐标  
				Vector3 point = hit.point;  
				//转向  
				transform.LookAt(new Vector3(point.x, transform.position.y, point.z));  
				//设置寻路的目标点  
				agent.SetDestination(point);  
			}  
		}
//		Debug.Log ("x  " + transform.position.x + "z   " + transform.position.z);
		if (transform.position.x < -13 && transform.position.z > 13) {
//			destoryMaze ();
//			this.refreshPlayerPosion ();
		}
	}

	private void destoryMaze(){
		GameObject[] walls = GameObject.FindGameObjectsWithTag("wallItem");
		for (int i = 0; i < walls.Length; i++) {
			Destroy (walls [i]);
		}
	}

	private void refreshPlayerPosion(){
		transform.position += new Vector3 (0, 0, -5);
//		agent.Stop ();
	}

	void Shoot() {
		timer = 0f;
		gunLine.enabled = true;
		//gunLine.SetPosition(0, transform.position);
		Vector3 mouse = Input.mousePosition;
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{
			gunLine.SetPosition(1, shootHit.point);
			Debug.Log ("11111");
		}
		else {
			//			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
			gunLine.SetPosition(1,transform.position + shootRay.direction * range);
			Debug.Log ("22222      shootRay.origin  "+shootRay.origin+"    shootRay.direction "+shootRay.direction+"  range  "+range);
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
	}
		
}
