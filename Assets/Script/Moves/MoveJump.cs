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
		controller = this.GetComponent<Controller> ();
		player = this.GetComponent<Player> ();
	}

	void FixedUpdate () {
		anim.SetBool (jump, controller.GetButton(BUTTON.UP));
		anim.SetBool (jumpFoward, controller.GetButton(BUTTON.UP)&&controller.GetButton(BUTTON.RIGHT));
		anim.SetBool (jumpBack, controller.GetButton(BUTTON.UP)&&controller.GetButton(BUTTON.LEFT));
		if (!anim.GetBool ("OnMove") && anim.GetBool("OnGround")) {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
				player.moveDirection.y = force.y;
			}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("JumpFoward")) {
				player.moveDirection.y = force.y;
				player.moveDirection.x = force.x*player.direction;
			}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("JumpBack")) {
				player.moveDirection.y = force.y;
				player.moveDirection.x = -force.x*player.direction;
			}
		}

	}

}
