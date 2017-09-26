using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentMove : MonoBehaviour {
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		//鼠标左键点击  
		if (Input.GetMouseButtonDown(1))  
		{  
			if (agent.isStopped) {
				agent.Resume ();
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
		Debug.Log ("x  " + transform.position.x + "z   " + transform.position.z);
		if (transform.position.x < -13 && transform.position.z > 13) {
			destoryMaze ();
			this.refreshPlayerPosion ();
		}
	}

	void OnCollisionEnter(Collision col){
//		string name = col.collider.name;
//		if (name.Equals ("upDoor")) {
//			destoryMaze ();
//		}
	}

	private void destoryMaze(){
		GameObject[] walls = GameObject.FindGameObjectsWithTag("wallItem");
		for (int i = 0; i < walls.Length; i++) {
			Destroy (walls [i]);
		}
	}

	private void refreshPlayerPosion(){
		transform.position += new Vector3 (0, 0, -5);
		agent.Stop ();
	}
}
