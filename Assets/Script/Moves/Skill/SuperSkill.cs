using UnityEngine;
using System.Collections;

public class SuperSkill : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public Button[] key;
	public	 Button[] mappedKeys;
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
	private MoveState moveState;

	void Start(){
		controller = this.GetComponent<Player> ().controller;
		mappedKeys = new Button[key.Length];
		for (int i = 0; i < key.Length; i++) {
			mappedKeys [i] = key [i];
		}
		moveState = new MoveState (anim, stateName,true);
	}

	void Update () {
		InvertControls ();
		moveState.ManageState ();
		if (OnAir != anim.GetBool ("OnGround")) {
			if (anim.GetBool ("Combo" + stateName)) {anim.SetBool ("Combo" + stateName, false);}
			if (controller.GetButtonDown (mappedKeys [state])) {
				state++;
				time = 0.5f;
				if (state == mappedKeys.Length) {
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

	}
	void Return(){
		Player.time = 1;
	}
	void InvertControls(){
		for (int i = 0; i < key.Length; i++) {
			if (player.direction == -1) {
				if (key [i] == Button.BACK) {
					mappedKeys [i] = Button.FORWARD;
				}
				if (key [i] == Button.FORWARD) {
					mappedKeys [i] = Button.BACK;
				}
			}
			if (player.direction == 1) {
				if (key [i] == Button.BACK) {
					mappedKeys [i] = key[i];
				}
				if (key [i] == Button.FORWARD) {
					mappedKeys [i] = key[i];
				}
			}
		}
	}
}
