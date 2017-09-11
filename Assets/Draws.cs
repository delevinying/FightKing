using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draws : MonoBehaviour {

	// Use this for initialization

	public Texture2D texture;
	void Start () {
		OnGUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		Rect rect = new Rect(Input.mousePosition.x - (texture.width/2),

			Screen.height - Input.mousePosition.y - (texture.height/2),

			texture.width, texture.height);

		GUI.DrawTexture(rect, texture);

	}
}
