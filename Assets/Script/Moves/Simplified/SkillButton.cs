using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {

	private Player player;
	private Animator anim;
	private Controller controller;
	public Button key;
	public string defaultAnimName;
	public string airAnimName;
	public string crounchAnimName;
	private bool defaultState;
	private bool airState;
	private bool crounchState;

	void Start(){
		player = this.GetComponent<Player> ();
		anim = player.anim;
		controller = player.controller;
	}

	void Update () {
		//Don't work here 	
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName (defaultAnimName) && defaultState == true) {
			anim.SetBool ("OnMove", false);
			defaultState = false;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (defaultAnimName) && defaultState == false) {
			anim.SetBool ("OnMove", true);
			defaultState = true;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (defaultAnimName)) {
			anim.SetBool ("OnMove", true);
		}

		//=========================================================
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName (airAnimName) && airState == true) {
			anim.SetBool ("OnMove", false);
			airState = false;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (airAnimName) && airState == false) {
			anim.SetBool ("OnMove", true);
			airState = true;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (airAnimName)) {
			anim.SetBool ("OnMove", true);
		}

		//====================================================
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName (crounchAnimName) && crounchState == true) {
			anim.SetBool ("OnMove", false);
			crounchState = false;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (crounchAnimName) && crounchState == false) {
			anim.SetBool ("OnMove", true);
			crounchState = true;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (crounchAnimName)) {
			anim.SetBool ("OnMove", true);
		}
		//====================================================
		if (!anim.GetBool ("OnGuard") && !anim.GetBool ("OnGuardDown") && !anim.GetBool ("OnStun")) {
			if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == false) {
				anim.SetBool ("Combo" + defaultAnimName, controller.GetButtonDown (key));
				if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove") && !anim.GetBool ("Jump")) {
					anim.Play (defaultAnimName);
					Debug.Log ("Soco");
				}
			}
			if (anim.GetBool ("OnGround") == false && anim.GetBool ("Crounch") == false) {
				anim.SetBool ("Combo" + airAnimName, controller.GetButtonDown (key));
				if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove")) {
					anim.Play (airAnimName);
				}
			}
			if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == true) {
				anim.SetBool ("Combo" + crounchAnimName, controller.GetButtonDown (key));
				if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove")) {
					anim.Play (crounchAnimName);
				}
			}
		}
	}
}
