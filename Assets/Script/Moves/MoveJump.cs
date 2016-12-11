using UnityEngine;
using System.Collections;

public class MoveJump : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public BUTTON[] key;
	public string stateName;
	public Vector2 force;

	void Start(){
		controller = this.GetComponent<Controller> ();
	}

	void FixedUpdate () {
		if (CheckComand() && anim.GetBool ("OnGround")) {
			anim.SetBool (stateName, CheckComand());
		} 
		anim.SetBool (stateName, CheckComand());
	}
	bool CheckComand(){
		for (int i = 0; i < key.Length; i++) {
			if (controller.GetButton(key[i]) == false) {
				return false;
			}
		}
		return true;
	}
}
