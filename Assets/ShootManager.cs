using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

	public float range = 0.001f;//射击范围
	public float timeBetweenBullets = 0.15f;//发射子弹的间隔
	float effectsDisplayTime = 0.2f;//子弹消失的时间
	float timer;//计时器

	Ray shootRay; //定义射线
	RaycastHit shootHit;
	LineRenderer gunLine;

	int shootableMask;//定义接受射线的面，mask

	void Awake(){
		shootableMask = LayerMask.GetMask("Shootable");
		gunLine = GetComponent<LineRenderer>();
		gunLine.useWorldSpace = false;
		gunLine.SetWidth (0.2f, 0.2f);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("timer,timeBetweenBullets:" + timer + "," + timeBetweenBullets);
			Shoot();
		}
		if (timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects();
		}
	}

	void Shoot() {
		timer = 0f;
		gunLine.enabled = true;
		//gunLine.SetPosition(0, transform.position);
		Vector3 mouse = Input.mousePosition;
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{
			gunLine.SetPosition(1, shootHit.point);
			Debug.Log ("11111");
		}
		else {
//			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
			gunLine.SetPosition(1,transform.position + shootRay.direction * range);
			Debug.Log ("22222      shootRay.origin  "+shootRay.origin+"    shootRay.direction "+shootRay.direction+"  range  "+range);
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
	}
}
