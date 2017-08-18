using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManController : MonoBehaviour {

	// Use this for initialization

	private int speed = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
	}
}
