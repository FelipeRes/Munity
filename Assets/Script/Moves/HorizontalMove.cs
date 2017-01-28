using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour {

	public Animator anim;
	public Player player;
	public string walkBackStateName;
	public string walkFowardStateName;
	public Vector2 movement;

	void Start(){
		player = this.GetComponent<Player> ();
	}

	void Update () {
		if (anim.GetBool ("OnGround")) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsName (walkFowardStateName)) {
				Vector2 vetor = this.transform.position;
				this.transform.Translate (movement * 0.16f*player.direction);
			}
			if (anim.GetCurrentAnimatorStateInfo (0).IsName (walkBackStateName)) {
				Vector2 vetor = this.transform.position;
				this.transform.Translate (movement * 0.16f*-player.direction);
			}
		}
		if (player.direction == 1) {
			anim.SetBool (walkBackStateName, player.controller.GetButton (Button.BACK));
			anim.SetBool (walkFowardStateName, player.controller.GetButton (Button.FORWARD));
		} else {
			anim.SetBool (walkBackStateName, player.controller.GetButton (Button.FORWARD));
			anim.SetBool (walkFowardStateName, player.controller.GetButton (Button.BACK));
		}
	}
}
