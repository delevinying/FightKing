using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

//	private Transform player;
//	private Vector3 direction;
//	public GameObject gameObj;
//	// Use this for initialization
//	void Start () 
//	{
//		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
//		player = gameObj.transform;
//		direction = player.position - transform.position;
//	}
//
//	// LateUpdate is called after Update each frame
//	void LateUpdate () 
//	{
//		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
//		transform.position = player.position - direction;
//	}


	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}
