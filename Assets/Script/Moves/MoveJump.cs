using UnityEngine;
using System.Collections;

public class MoveJump : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public string jump;
	public string jumpFoward;
	public string jumpBack;
	public Vector2 force;
	public Player player;

	void Start(){
		player = this.GetComponent<Player> ();
		controller = player.controller;
	}

	void FixedUpdate () {
		if (anim.GetBool("OnGround")) {
			if (player.direction == 1) {
				anim.SetBool (jumpFoward, controller.GetButton (Button.UP) && controller.GetButton (Button.FORWARD));
				anim.SetBool (jumpBack, controller.GetButton (Button.UP) && controller.GetButton (Button.BACK));
				anim.SetBool (jump, controller.GetButton(Button.UP));
			} else if(player.direction == -1) {
				anim.SetBool (jumpFoward, controller.GetButton (Button.UP) && controller.GetButton (Button.BACK));
				anim.SetBool (jumpBack, controller.GetButton (Button.UP) && controller.GetButton (Button.FORWARD));
				anim.SetBool (jump, controller.GetButton(Button.UP));
			}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("JumpFoward")) {
				player.moveDirection.y = force.y;
				player.moveDirection.x = force.x*player.direction;
				anim.SetBool ("OnMove", false);
			}else if (anim.GetCurrentAnimatorStateInfo(0).IsName("JumpBack")) {
				player.moveDirection.y = force.y;
				player.moveDirection.x = -force.x*player.direction;
				anim.SetBool ("OnMove", false);
			}else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
				player.moveDirection.y = force.y;
				anim.SetBool ("OnMove", false);
			}
		}

	}

}
