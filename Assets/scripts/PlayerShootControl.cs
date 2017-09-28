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

		Ray ray = new Ray(transform.position, -transform.up);  
		RaycastHit hit;  
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))  
		{  
			// 如果射线与平面碰撞，打印碰撞物体信息  
			Debug.Log("碰撞对象: " + hit.collider.name);  
			// 在场景视图中绘制射线  
			Debug.DrawLine(ray.origin, hit.point, Color.red); 
		}



//
//		Ray mouseRay= myCamera.ScreenPointToRay (Input .mousePosition );
//		tempBall=Instantiate (bullet ,mouseRay .origin ,Quaternion .identity )as GameObject;
//		tempBall.GetComponent<Rigidbody>().velocity 
//		=mouseRay .direction*speed ;
//		Destroy (tempBall ,2.5f);
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
