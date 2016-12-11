﻿using UnityEngine;
using System.Collections;

public class AdvanceSkill : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public BUTTON[] key;
	public string stateName;
	public bool ignoreGravity;
	private bool changeState;
	public int state;
	public float time;

	void Start(){
		controller = this.GetComponent<Controller> ();
	}

	void Update () {
		if (anim.GetBool ("Combo"+stateName)) {
			anim.SetBool ("Combo" + stateName, false);

		}
		if (controller.GetButtonDown(key[state])) {
			state++;
			time = 0.5f;
			if (state == key.Length) {
				anim.Play (stateName);
				state = 0;
				anim.SetBool ("OnMove", true);
				anim.SetBool ("IgnoreGravity", true);
				anim.SetBool ("Combo"+stateName,true);
				anim.SetBool ("Combo" + stateName, true);
			}
		}
		if (time > 0) {
			time -= Time.deltaTime;
		} else {
			time = 0;
			state = 0;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (stateName) && changeState == false) {
			anim.SetBool ("OnMove", true);
			anim.SetBool ("IgnoreGravity", true);
			changeState = true;
		}
		if (changeState == true && !anim.GetCurrentAnimatorStateInfo (0).IsName (stateName)) {
			anim.SetBool ("OnMove", false);
			anim.SetBool ("IgnoreGravity", false);
			changeState = false;
		}
	}
}
