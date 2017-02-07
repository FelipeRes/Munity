using System;
using UnityEngine;

public class MoveState{

	private Animator anim;
	private string animationName;
	private bool value;
	private bool ingnoryGravity;

	public MoveState (Animator anim, string animationName){
		this.anim = anim;
		this.animationName = animationName;
		this.ingnoryGravity = false;
	}
	public MoveState (Animator anim, string animationName, bool ingnoryGravity){
		this.anim = anim;
		this.animationName = animationName;
		this.ingnoryGravity = ingnoryGravity;
	}

	public void ManageState(){
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName (animationName) && value == true) {
			anim.SetBool ("OnMove", false);
			if (ingnoryGravity) {
				anim.SetBool ("IgnoreGravity", false);
			}
			value = false;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (animationName) && value == false) {
			anim.SetBool ("OnMove", true);
			value = true;
			if (ingnoryGravity) {
				anim.SetBool ("IgnoreGravity", true);
			}
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (animationName)) {
			anim.SetBool ("OnMove", true);
		}
	}


}

