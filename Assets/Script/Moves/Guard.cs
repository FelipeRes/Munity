using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public Animator anim;
	public Player player;
	public Animator enemyAnimator;
	public Controller controller;

	void Start(){
		controller = this.GetComponent<Controller> ();
	}

	void Update () {
		/*if (enemyAnimator.GetBool ("OnMove") && controller.GetButton (BUTTON.LEFT) && !anim.GetBool("OnStun")) {
			if (controller.GetButton (BUTTON.DOWN)) {
				anim.SetBool ("OnGuardDown", true);
			} else {
				anim.SetBool ("OnGuard", true);
			}
		} else {
			anim.SetBool ("OnGuard", false);
			anim.SetBool ("OnGuardDown", false);
		}*/
		if ( player.CheckMove() && controller.GetButton (BUTTON.LEFT) && !anim.GetBool("OnStun")) {
			if (controller.GetButton (BUTTON.DOWN)) {
				anim.SetBool ("OnGuardDown", true);
			} else {
				anim.SetBool ("OnGuard", true);
			}
		} else {
			anim.SetBool ("OnGuard", false);
			anim.SetBool ("OnGuardDown", false);
		}
	
	}

}
