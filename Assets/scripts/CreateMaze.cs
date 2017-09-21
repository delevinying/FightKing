using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour {

	public GameObject wallItem;
	public int startX;
	public int startY;
	public int[,] mazeNum=new int[,]
	{ 
		{1,0,1,1,1,1,1,1,1,1},
		{1,0,0,1,0,0,0,0,0,1},
		{1,1,0,1,0,1,0,1,0,1},
		{1,0,0,0,0,1,1,1,0,1},
		{1,0,1,1,0,0,0,1,0,1},
		{1,0,0,1,0,1,1,1,0,1},
		{1,1,0,0,0,1,0,0,0,1},
		{1,0,0,1,0,1,1,0,1,1},
		{1,1,0,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,0,1}
	};
	// Use this for initialization
	void Start () {
		drawWall ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void drawWall(){
		for (int x = 0; x < 10; x++)
		{
			for (int y = 0; y < 10; y++)
			{
				if (mazeNum [x, y] == 1) {
					Instantiate (wallItem, new Vector3 (startX + 2*(x - 1), 0, startY + 2*(y - 1)), Quaternion.identity);
				}
			}
		}
	}
}
