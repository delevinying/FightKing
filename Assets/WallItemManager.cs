using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItemManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag=="bullet")
		{
			Debug.Log ("xiaosssssssss   ");
			Destroy (collider.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
