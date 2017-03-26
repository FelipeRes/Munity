using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

	public Player player;
	public Controller controller;
	public string dashAnimation;

	void Start () {
		player = this.GetComponent<Player> ();
		controller = player.controller;
	}
	

	void Update () {
		if (controller.GetButtonDown (Button.A) && controller.GetButtonDown (Button.B) && !player.anim.GetBool("OnMove") && !player.anim.GetBool("OnHit")) {
			player.anim.Play ("Dash");
		}
	}
}
