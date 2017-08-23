using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKey (KeyCode.H)) {
//			transform.Translate (Vector3.forward * 0.03f);
//		}
//

		if (Input.GetKey (KeyCode.W)) {
//			_animator.SetInteger ("state", 1);
			transform.Translate (Vector3.forward * 0.03f);
			_animator.SetBool ("isAttact", true);
			_animator.SetBool ("isBack", false);
			_animator.SetBool ("isLeft", false);
			_animator.SetBool ("isRight", false);
		}
		if (Input.GetKeyDown (KeyCode.S)){
//			_animator.SetInteger ("state", 3);
			_animator.SetBool ("isAttact", false);
			_animator.SetBool ("isBack", true);
			_animator.SetBool ("isLeft", false);
			_animator.SetBool ("isRight", false);
		}
		if (Input.GetKeyDown (KeyCode.A)){
//			_animator.SetInteger ("state", 4);
			_animator.SetBool ("isAttact", false);
			_animator.SetBool ("isBack", false);
			_animator.SetBool ("isLeft", true);
			_animator.SetBool ("isRight", false);
		}
		if (Input.GetKeyDown (KeyCode.D)){
//			_animator.SetInteger ("state", 2);
			_animator.SetBool ("isAttact", false);
			_animator.SetBool ("isBack", false);
			_animator.SetBool ("isLeft", false);
			_animator.SetBool ("isRight", true);
		}
	}
}
