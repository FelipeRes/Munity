using UnityEngine;
using System.Collections;

public class AdvanceSkill : MonoBehaviour {

	public Animator anim;
	public SkillType trype;
	public Player player;
	public Button[] key;
	private Button[] mappedKeys;
	public string stateName;
	public bool ignoreGravity;
	private bool changeState;
	public bool OnAir;
	public int state;
	public float time;
	public MoveState moveState;

	void Start(){
		player = this.GetComponent<Player> ();
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
			if (anim.GetBool ("Combo" + stateName)) {
				anim.SetBool ("Combo" + stateName, false);
			}
			if (player.controller.GetButtonDown (mappedKeys [state])) {
				state++;
				time = 0.5f;
				if (state == mappedKeys.Length) {
					if (!anim.GetBool ("OnMove") && !anim.GetBool("OnStun")) {
						anim.Play (stateName);
						anim.SetBool ("OnMove", true);
						anim.SetBool ("IgnoreGravity", true);
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

	//=========================================================================//
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
