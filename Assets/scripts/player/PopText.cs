using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour {

	private Color[] colors = new Color[]{ Color.red, Color.yellow, Color.blue };
	public TextMesh textMesh;
	public Camera mainCamera;
	private Vector3 targetPosition;
	private float destoryTime;

	void Awake(){
		this.textMesh = this.GetComponentInParent<TextMesh> ();
	}

	// Use this for initialization
	void Start () {
		this.changeData (100, transform.position, GetComponent<Camera>());
	}

	private void changeData(int hurt,Vector3 position,Camera mainCamera){
		this.mainCamera = mainCamera;
		this.textMesh.text = "- " + hurt.ToString();
		this.textMesh.color = this.colors[Random.Range(0, this.colors.Length)];
		this.targetPosition = position + new Vector3 (Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0f) * 15f;
		this.transform.position = position;
		this.destoryTime = Time.time;
	}


	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("Update  this.destoryTime  "+this.destoryTime);
		if(this.destoryTime == 0) return;
		// 1秒钟后消失
		if(Time.time - this.destoryTime <= 1f)
		{
			Vector3 direction = this.transform.position - this.mainCamera.transform.position;
			direction.y = 0f;
			this.transform.rotation = Quaternion.LookRotation (direction);
			this.transform.position = Vector3.Lerp (this.transform.position, this.targetPosition, Time.deltaTime);
		}else{
			Destroy(this.gameObject);
		}
	}
}
