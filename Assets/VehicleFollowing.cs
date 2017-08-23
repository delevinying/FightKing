using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFollowing : MonoBehaviour {

	public Path path;  
	public float speed = 20.0f;    //速度  
	public float mass = 5.0f;      //质量  
	public bool isLooping = true;  //是否循环运动  

	//Actual speed of the vehicle   
	private float curSpeed;  

	private int curPathIndex;    //开始时所在的导航点  
	private float pathLength;    //整个路径的长度  
	private Vector3 targetPoint; //下一个导航点  

	Vector3 velocity;  

	// Use this for initialization
	void Start () {
		pathLength = path.Length;  
		curPathIndex = 0;          

		//get the current velocity of the vehicle  
		velocity = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		//Unify the speed  
		curSpeed = speed * Time.deltaTime;  

		targetPoint = path.GetPoint(curPathIndex);  

		//If reach the radius within the path then move to next point in the path  
		if(Vector3.Distance(transform.position, targetPoint) < path.Radius)  
		{  
			//Don't move the vehicle if path is finished   
			if (curPathIndex < pathLength - 1)  //判断是否到了终点  
				curPathIndex ++;  
			else if (isLooping)  
				curPathIndex = 0;  
			else  
				return;  
		}  

		//Move the vehicle until the end point is reached in the path  
		if (curPathIndex >= pathLength )  
			return;  

		//Calculate the next Velocity towards the path  
		if(curPathIndex >= pathLength - 1 && !isLooping)  
			velocity += Steer(targetPoint, true);   //Steer计算加速度  
		else  
			velocity += Steer(targetPoint);  

		transform.position += velocity; //Move the vehicle according to the velocity  
		transform.rotation = Quaternion.LookRotation(velocity); //Rotate the vehicle towards t
	}

	public Vector3 Steer(Vector3 target, bool bFinalPoint = false)  
	{  
		//Calculate the directional vector from the current position towards the target point  
		Vector3 desiredVelocity = (target - transform.position);  
		float dist = desiredVelocity.magnitude;  

		//Normalise the desired Velocity  
		desiredVelocity.Normalize();  

		//Calculate the velocity according to the speed  
		if (bFinalPoint && dist < 10.0f)  
			desiredVelocity *= (curSpeed * (dist / 10.0f));  
		else   
			desiredVelocity *= curSpeed;  

		//Calculate the force Vector  
		Vector3 steeringForce = desiredVelocity - velocity;   
		Vector3 acceleration = steeringForce / mass;  

		return acceleration;  
	}  
}
