using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour {


	public Object obj;
	private int force = 300000;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			
			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			GameObject gameobject = (GameObject)Instantiate (obj, this.transform.position,
				Quaternion.identity);
			Debug.Log ("生成子弹     "+mouseRay.direction);
			gameobject.GetComponent<Rigidbody> ().AddForce (mouseRay.direction*force); 
//			Debug.DrawLine(ray.origin, hit.point, Color.red); 
//			Debug.DrawRay(transform.position,mouseRay.direction);
//			Debug.DrawLine (transform.position, Input.mousePosition,Color.red);
			Debug.DrawLine(transform.position, Input.mousePosition, Color.green, 1, false);
		}
	}
}
