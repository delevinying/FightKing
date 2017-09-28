using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour {

	private Vector3 mTarget;
	private Vector3 mScreen;
	public int values;
	public float ContentWidth = 100;
	public float ContentHeight = 50;
	private Vector2 mPoint;
	public float FreeTime = 0.5F;

	void Start () {
		mTarget = transform.position;
		mScreen = Camera.main.WorldToScreenPoint (mTarget);
		mPoint = new Vector2 (mScreen.x, Screen.height - mScreen.y);
		StartCoroutine ("Free");
	}

	void Update () {
		//使文本在垂直方向山产生一个偏移
		transform.Translate(Vector3.up * 0.5F * Time.deltaTime);
		//重新计算坐标
		mTarget=transform.position;
		//获取屏幕坐标
		mScreen= Camera.main.WorldToScreenPoint(mTarget);
		//将屏幕坐标转化为GUI坐标
		mPoint=new Vector2(mScreen.x,Screen.height-mScreen.y);
	}

	void OnGUI()
	{
		//保证目标在摄像机前方
		if(mScreen.z>0)
		{
			//内部使用GUI坐标进行绘制
			GUI.Label(new Rect(mPoint.x,mPoint.y,ContentWidth,ContentHeight),values.ToString());
		}
	}

	IEnumerator Free()
	{
		yield return new WaitForSeconds(FreeTime);
		Destroy(this.gameObject);
	}
}
