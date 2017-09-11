using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapManager : MonoBehaviour {

	public Material diffuseMap;
	public Texture2D heightMap;
	private Vector3[] vertives;
	private Vector2[] uvs;
	private int[] triangles;

	private Vector2 size;
	private float minHeight = -10;
	private float maxHeight = 10;
	private Vector2 segment;
	private float unitH;

	private GameObject terrain;

	// Use this for initialization
	void Start () {
		SetTerrain ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTerrain(){
		SetTerrain (100, 100, 50, 50, -10, 10);
	}

	public void SetTerrain(float width, float height, uint segmentX, uint segmentY,int min,int max)
	{
		Init(width, height, segmentX, segmentY,min,max);
		GetVertives();
		DrawMesh();
	}

	private void Init(float width, float height, uint segmentX, uint segmentY, int min, int max)
	{
		size = new Vector2(width, height);
		maxHeight = max;
		minHeight = min;
		unitH = maxHeight - minHeight;
		segment = new Vector2(segmentX, segmentY);
		if (terrain != null)
		{
			Destroy(terrain);
		}
		terrain = new GameObject();
		terrain.name = "plane";
	}

	private void DrawMesh()
	{
//		Mesh mesh = terrain.AddComponent<MeshFilter>().mesh;
//		terrain.AddComponent<MeshRenderer>();
//		if (diffuseMap == null)
//		{
//			Debug.LogWarning("No material,Create diffuse!!");
//			diffuseMap = new Material(Shader.Find("Diffuse"));
//		}
//		if (heightMap==null)
//		{
//			Debug.LogWarning("No heightMap!!!");
//		}
//
//		terrain.GetComponent("Renderer").material = diffuseMap;
//		//给mesh 赋值
//		mesh.Clear();
//		mesh.vertices = vertives;//,pos);
//		mesh.uv = uvs;
//		mesh.triangles = triangles;
//		//重置法线
//		mesh.RecalculateNormals();
//		//重置范围
//		mesh.RecalculateBounds();
	}

	private Vector3[] GetVertives()
	{
		int sum = Mathf.FloorToInt((segment.x + 1) * (segment.y + 1));
		float w = size.x / segment.x;
		float h = size.y / segment.y;

		int index = 0;
		GetUV();
		GetTriangles();
		vertives = new Vector3[sum];
		for (int i = 0; i < segment.y + 1; i++)
		{
			for (int j = 0; j < segment.x + 1; j++)
			{
				float tempHeight = 0;
				if (heightMap != null)
				{
					tempHeight = GetHeight(heightMap, uvs[index]);
				}
				vertives[index] = new Vector3(j * w, tempHeight, i * h);
				index++;
			}
		}
		return vertives;
	}

	private Vector2[] GetUV()
	{
		int sum =Mathf.FloorToInt( (segment.x + 1) * (segment.y + 1));
		uvs = new Vector2[sum];
		float u = 1.0F / segment.x;
		float v = 1.0F / segment.y;
		uint index = 0;
		for (int i = 0; i < segment.y + 1; i++)
		{
			for (int j = 0; j < segment.x + 1; j++)
			{
				uvs[index] = new Vector2(j * u, i * v);
				index++;
			}
		}
		return uvs;
	}

	private int[] GetTriangles()
	{
		int sum = Mathf.FloorToInt(segment.x * segment.y * 6);
		triangles = new int[sum];
		uint index = 0;
		for (int i = 0; i < segment.y; i++)
		{
			for (int j = 0; j < segment.x; j++)
			{
				int role = Mathf.FloorToInt(segment.x) + 1;
				int self = j +( i*role);                
				int next = j + ((i+1) * role);
				triangles[index] = self;
				triangles[index + 1] = next + 1;
				triangles[index + 2] = self + 1;
				triangles[index + 3] = self;
				triangles[index + 4] = next;
				triangles[index + 5] = next + 1;
				index += 6;
			}
		}
		return triangles;
	}

	private float GetHeight(Texture2D texture, Vector2 uv)
	{       
		if (texture != null)
		{
			//提取灰度。如果强制读取某个通道，可以忽略
			Color c = GetColor(texture, uv);
			float gray = c.grayscale;//或者可以自己指定灰度提取算法，比如：gray = 0.3F * c.r + 0.59F * c.g + 0.11F * c.b;
			float h = unitH * gray;
			return h;
		}
		else
		{
			return 0;
		}
	}

	private Color GetColor(Texture2D texture, Vector2 uv)
	{

		Color color = texture.GetPixel(Mathf.FloorToInt(texture.width * uv.x), Mathf.FloorToInt(texture.height * uv.y));
		return color;
	}

	public void SetPos(Vector3 pos)
	{
		if (terrain)
		{
			terrain.transform.position = pos;
		}
		else
		{
			SetTerrain();
			terrain.transform.position = pos;
		}
	}
}
