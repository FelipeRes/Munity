using UnityEngine;
using System.Collections;

public class SuperSkill : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public BUTTON[] key;
	public string stateName;
	public bool ignoreGravity;
	private bool changeState;
	public bool OnAir;
	public int state;
	public float time;
	public int gauge;
	public Player player;
	public GameObject lightEffect;
	public GameObject effctPoint;
	void Start(){
		controller = this.GetComponent<Controller> ();
	}

	void Update () {
		if (OnAir != anim.GetBool ("OnGround")) {
			if (anim.GetBool ("Combo" + stateName)) {
				anim.SetBool ("Combo" + stateName, false);
			}
			if (controller.GetButtonDown (key [state])) {
				state++;
				time = 0.5f;
				if (state == key.Length) {
					if (player.gauge >= gauge && !anim.GetBool("OnStun") && !anim.GetBool ("OnMove")) {
						player.gauge -= gauge;
						anim.Play (stateName);
						anim.SetBool ("OnMove", true);
						anim.SetBool ("IgnoreGravity", true);
						GameObject effect = Instantiate (lightEffect, effctPoint.transform.position, Quaternion.identity) as GameObject;
						Destroy (effect, 2);
						Player.time = 0;
						Invoke ("Return", 0.1f);
						Debug.Log ("Especial");
					}
					state = 0;
					anim.SetBool ("Combo" + stateName, true);
				}
			}
		}
		if (time > 0) {
			time -= Time.deltaTime;
		} else {
			time = 0;
			state = 0;
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (stateName) && changeState == false) {
			anim.SetBool ("OnMove", true);
			anim.SetBool ("IgnoreGravity", true);
			changeState = true;
		}
		if (changeState == true && !anim.GetCurrentAnimatorStateInfo (0).IsName (stateName)) {
			anim.SetBool ("OnMove", false);
			anim.SetBool ("IgnoreGravity", false);
			changeState = false;
		}
	}
	void Return(){
		Player.time = 1;
	}
}
