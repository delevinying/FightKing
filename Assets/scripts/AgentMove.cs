using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentMove : MonoBehaviour {
//	private NavMeshAgent agent;
	void Start () {
//		agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		
	}

	private void destoryMaze(){
		GameObject[] walls = GameObject.FindGameObjectsWithTag("wallItem");
		for (int i = 0; i < walls.Length; i++) {
			Destroy (walls [i]);
		}
	}

	private void refreshPlayerPosion(){
		transform.position += new Vector3 (0, 0, -5);
		//agent.Stop ();
	}
}
