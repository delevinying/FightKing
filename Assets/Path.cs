﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	public bool isDebug = true;
	public float Radius = 2.0f;
	public Vector3[] pointA; 



	public float Length  
	{  
		get  
		{  
			return pointA.Length; //返回数组长度  
		}  
	}  

	public Vector3 GetPoint(int index)  
	{  
		return pointA[index];      //返回导航数字  
	}  

	void OnDrawGizmos()  
	{  
		if (!isDebug)  
			return;  

		for (int i = 0; i < pointA.Length; i++)  
		{  
			if (i + 1 < pointA.Length)  
			{  
				Debug.DrawLine(pointA[i], pointA[i + 1], Color.red);  
			}  
		}  
	}  



	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
