using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour {


	public Object obj;
	private int force = 300;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("生成子弹");
			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			GameObject gameobject = (GameObject)Instantiate (obj, this.transform.position,
				Quaternion.identity);
			gameobject.GetComponent<Rigidbody> ().AddForce (mouseRay.direction*force); 
		}
	}
}
