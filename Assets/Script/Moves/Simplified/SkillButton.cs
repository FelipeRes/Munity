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
	public MoveState defaultMoveUtils;
	public MoveState airMoveUtils;
	public MoveState crounchMoveUtils;

	void Start(){
		player = this.GetComponent<Player> ();
		anim = player.anim;
		controller = player.controller;
		defaultMoveUtils = new MoveState (anim, defaultAnimName); 
		airMoveUtils = new MoveState (anim, airAnimName); 
		crounchMoveUtils = new MoveState (anim, crounchAnimName); 
	}

	void Update () {
		defaultMoveUtils.ManageState ();
		airMoveUtils.ManageState ();
		crounchMoveUtils.ManageState ();

		if (!anim.GetBool ("OnGuard") && !anim.GetBool ("OnGuardDown") && !anim.GetBool ("OnStun")) {
			if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == false) {
				if (anim.GetBool ("OnMove") && !anim.GetBool ("Combo" + defaultAnimName)) {
					if (controller.GetButtonDown (key)) {
						anim.SetBool ("Combo" + defaultAnimName, true);
					}
				} else if(!anim.GetBool ("OnMove")){
					anim.SetBool ("Combo" + defaultAnimName, false);
				}
				if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove") && !anim.GetBool ("Jump")) {
					anim.Play (defaultAnimName);
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
