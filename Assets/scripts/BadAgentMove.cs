using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BadAgentMove : MonoBehaviour {
	private int[,] mazeArray;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		mazeArray = CreateMaze.mazeNum;
		goPosition ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void goPosition(){
		int x = 0;
		int y = 0;
		do {
			x = Random.Range (4, 25);
			y = Random.Range (4, 25);
		} while(mazeArray [x, y] == 1);
		Vector3 point = new Vector3 (x, 0, y);
		//转向  
		transform.LookAt(new Vector3(x, transform.position.y, y));  
		//设置寻路的目标点  
		agent.SetDestination(point);  
	}
}
