using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed;
	public int health = 3;
	public int damage;
	public Transform targetTransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void collidedWithEnemy(Enemy enemy){
		if (health <= 0) {
			
		}
	}

	void OnCollisionEnter(Collision col){
		Enemy enemy = col.collider.gameObject.GetComponent<Enemy> ();
		collidedWithEnemy (enemy);
	}

	void FixedUpdate(){
		if (targetTransform != null) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, 
				targetTransform.transform.position, Time.deltaTime * moveSpeed);
		}
	}

	public void TakeDamage(int damage) {
		health -= damage;
		if(health <= 0) {
			Destroy(this.gameObject);
		}
	}

	public void Attack(FighterPlayerMonement player) {
		player.health -= this.damage;
		Destroy(this.gameObject);
	}
}
