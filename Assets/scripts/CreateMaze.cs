using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour {

	public GameObject wallItem;
	public GameObject bad;
	public int startX;
	public int startY;
	public int maxBad;
	private int nowFoolr = 1;//所在塔层
	public int[,] mazeNum = null;
	void Start () {
		this.mazeNum = MazeArray.getArray (this.nowFoolr - 1);
		drawWall ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void drawWall(){
		for (int x = 0; x < 30; x++)
		{
			for (int y = 0; y < 30; y++)
			{
				if (mazeNum [x, y] == 1) {
					Instantiate (wallItem, new Vector3 (startX + (x - 1), 0, startY + (y - 1)), Quaternion.identity);
				} else if (mazeNum [x, y] == 2) {
					Instantiate (bad, new Vector3 (startX + (x - 1), 0, startY + (y - 1)), Quaternion.identity);
				}
			}
		}
	}
		
}
