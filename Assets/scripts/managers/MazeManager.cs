using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager{
	private static MazeManager mazeManager;

	public MazeManager(){
		
	}

	public static MazeManager GetInstance(){
		if (mazeManager == null) {
			mazeManager = new MazeManager ();
		}
		return mazeManager;
	}
}
