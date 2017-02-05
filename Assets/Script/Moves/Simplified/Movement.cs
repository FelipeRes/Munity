using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	private Player player;
	private Animator anim;
	private Controller controller;
	public string jump;
	public string jumpForward;
	public string jumpBack;
	public Vector2 jumpForce;
	public string crounch;
	public Vector2 movement;
	public string walkForward;
	public string walkBack;

	void Start(){
		player = this.GetComponent<Player> ();
		controller = player.controller;
		anim = player.anim;
	}

	void FixedUpdate () {
		if (anim.GetBool("OnGround")) {
			if (player.direction == 1) {
				anim.SetBool (jumpForward, controller.GetButton (Button.UP) && controller.GetButton (Button.FORWARD));
				anim.SetBool (jumpBack, controller.GetButton (Button.UP) && controller.GetButton (Button.BACK));
				anim.SetBool (jump, controller.GetButton(Button.UP));
				anim.SetBool (walkForward, player.controller.GetButton (Button.FORWARD));
				anim.SetBool (walkBack, player.controller.GetButton (Button.BACK));
			} else if(player.direction == -1) {
				anim.SetBool (jumpForward, controller.GetButton (Button.UP) && controller.GetButton (Button.BACK));
				anim.SetBool (jumpBack, controller.GetButton (Button.UP) && controller.GetButton (Button.FORWARD));
				anim.SetBool (jump, controller.GetButton(Button.UP));
				anim.SetBool (walkForward, player.controller.GetButton (Button.BACK));
				anim.SetBool (walkBack, player.controller.GetButton (Button.FORWARD));
			}
			anim.SetBool (crounch,player.controller.GetButton(Button.DOWN));
			//Horizontal Move
			if (anim.GetCurrentAnimatorStateInfo (0).IsName (walkForward)) {
				Vector2 vetor = this.transform.position;
				this.transform.Translate (movement * 0.16f*player.direction);
			}
			if (anim.GetCurrentAnimatorStateInfo (0).IsName (walkBack)) {
				Vector2 vetor = this.transform.position;
				this.transform.Translate (movement * 0.16f*-player.direction);
			}
			//Jump
			if (anim.GetCurrentAnimatorStateInfo(0).IsName(jumpForward)) {
				player.moveDirection.y = jumpForce.y;
				player.moveDirection.x = jumpForce.x*player.direction;
				anim.SetBool ("OnMove", false);
			}else if (anim.GetCurrentAnimatorStateInfo(0).IsName(jumpBack)) {
				player.moveDirection.y = jumpForce.y;
				player.moveDirection.x = -jumpForce.x*player.direction;
				anim.SetBool ("OnMove", false);
			}else if (anim.GetCurrentAnimatorStateInfo (0).IsName (jump)) {
				player.moveDirection.y = jumpForce.y;
				anim.SetBool ("OnMove", false);
			}
		}

	}
}
