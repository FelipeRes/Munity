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
		if ((enemy.CheckMove() || enemy.anim.GetBool("OnMove")) && !anim.GetBool("OnStun")  && !anim.GetBool("OnMove")) {
			if ((player.direction == 1 && controller.GetButton (Button.BACK)) || (player.direction == -1 && controller.GetButton (Button.FORWARD))) {
				if (controller.GetButton (Button.DOWN)) {
					anim.SetBool ("OnGuardDown", true);
				} else {
					anim.SetBool ("OnGuard", true);
				}
			}
		} else {
			anim.SetBool ("OnGuard", false);
			anim.SetBool ("OnGuardDown", false);
		}
	
	}

}
