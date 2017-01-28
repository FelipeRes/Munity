using UnityEngine;
using System.Collections;

public class MoveJump : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	//public BUTTON[] key;
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
			anim.SetBool (jumpFoward, controller.GetButton(Button.UP)&&controller.GetButton(Button.RIGHT));
			anim.SetBool (jumpBack, controller.GetButton(Button.UP)&&controller.GetButton(Button.LEFT));
			anim.SetBool (jump, controller.GetButton(Button.UP));
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
