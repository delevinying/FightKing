using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManController : MonoBehaviour {

	// Use this for initialization

//	private int speed = 1;
	private GameObject cherryObject;//目标对象
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
