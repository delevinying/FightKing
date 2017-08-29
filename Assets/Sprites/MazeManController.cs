using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManController : MonoBehaviour {

	private int l_rom;

//	private int speed = 1;
	private GameObject cherryObject;//目标对象
	void Start () {
		
	}
	private int _temp = 0;
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
		if (_temp == 0) {
			l_rom = Random.Range (0, 5); 
			_temp++;
		}
		if (_temp > 20) {
			_temp = 0;
		}
		if (l_rom == 1) {
			transform.position = new Vector3 (0,0.1f,0);
		} else if(l_rom ==2){
			transform.position = new Vector3 (0.1f,0,0);
		}
	}
}
