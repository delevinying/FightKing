using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FighterPlayerMonement : MonoBehaviour {


	public int health = 3;
	private Rigidbody rigidBody;
	private KeyCode[] inputKeys;
	private Vector3[] directionsForKeys;
	public float acceleration;
	public float maxSpeed;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
		directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update(){

//		controllAgent ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		for (int i = 0; i < inputKeys.Length; i++){
			var key = inputKeys[i];

			// 2
			if(Input.GetKey(key)) {
				// 3
				Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
				movePlayer (movement);
			}
		}
	}

	private void getAgent(){
		agent = GetComponent<NavMeshAgent> ();
	}

	private void controllAgent(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("地形   " + hit.collider.name);
				if (!hit.collider.name.Equals ("Cube")) {
					return;
				}
				Vector3 point = hit.point;
				transform.LookAt (new Vector3 (point.x, point.y, point.z));
				agent.SetDestination (point);
			}
		}
	}


	void movePlayer(Vector3 movement) {
		if(rigidBody.velocity.magnitude * acceleration > maxSpeed) {
			rigidBody.AddForce(movement * -1);
		} else {
			rigidBody.AddForce(movement);
		}
	}

	void collidedWithEnemy(Enemy enemy) {
		enemy.Attack(this);
		if(health <= 0) {
			// Todo 
		}
	}

	void OnCollisionEnter (Collision col) {
		Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
		if (enemy) {
			collidedWithEnemy (enemy);
		}
	}


	void controlFun(){
		if (Input.GetKey(KeyCode.W)) {
			gameObject.transform.position += new Vector3 (0, 0, 0.1f);
		}else if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.position += new Vector3 (-0.1f, 0, 0);
		}else if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.position += new Vector3 (0.1f, 0, 0);
		}else if (Input.GetKey(KeyCode.S)) {
			gameObject.transform.position += new Vector3 (0, -0.1f, 0);
		}
	}
}
