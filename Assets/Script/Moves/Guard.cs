using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public Animator anim;
	public Player player;
	public Player enemy;
	public Controller controller;

	void Start(){
		player = this.GetComponent<Player> ();
		enemy = player.enemy.GetComponent<Player> ();
		controller = player.controller;
	}

	void Update () {
		if ( enemy.CheckMove() && controller.GetButton (BUTTON.LEFT) && !anim.GetBool("OnStun")  && !anim.GetBool("OnMove")) {
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
