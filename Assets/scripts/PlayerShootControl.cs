using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootControl : MonoBehaviour {

	public GameObject bullet;
	public GameObject tempBall;
	public float speed = 20;
	public  Camera myCamera;
	// Use this for initialization
	void Start () {
		
	}

	void update(){
//		shoot ();
		Ray mouseRay=myCamera .ScreenPointToRay (Input .mousePosition );
		tempBall=Instantiate (bullet ,mouseRay .origin ,Quaternion .identity )as GameObject;
		tempBall.GetComponent<Rigidbody>().velocity 
		=mouseRay .direction*speed ;
		Destroy (tempBall ,2.5f);
	}

	void shoot(){
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("GetMouseButtonDown   ");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("地形   " + hit.collider.name);
				if (!hit.collider.name.Equals ("Cube")) {
					return;
				}
				Vector3 point= new Vector3(transform.position.x,transform.position.y+transform.localScale.y/2,transform.position.z);  
				//实例化一个子弹  
				Instantiate(bullet,point,Quaternion.identity);  
			}
		}

	}
}
