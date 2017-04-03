using UnityEngine;
using System.Collections;

public class AdvanceSkill : MonoBehaviour {

	private Animator anim;
	public SkillType trype;
	private Player player;
	public Button[] sequenceKey;
	public Button[] activeKey;
	private Button[] mappedKeys;
	public string stateName;
	public bool ignoreGravity;
	private bool changeState;
	public bool OnAir;
	private bool sequenceOk;
	private int state;
	private float time;
	private MoveState moveState;
	public AudioClip voiceSound;

	void Start(){
		player = this.GetComponent<Player> ();
		anim = player.anim;
		mappedKeys = new Button[sequenceKey.Length];
		for (int i = 0; i < sequenceKey.Length; i++) {
			mappedKeys [i] = sequenceKey [i];
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
			if (mappedKeys.Length > 0) {
				if (player.controller.GetButtonDown (mappedKeys [state])) {
					state++;
					time = 0.5f;
					if (state == mappedKeys.Length) {
						sequenceOk = true;
						state = 0;
					}
				}
			} else {
				sequenceOk = true;
				time = 1f;//need adjust
			}
		}
		if (time > 0) {
			time -= Time.deltaTime;
		} else {
			sequenceOk = false;
			time = 0;
			state = 0;
		}

		if (sequenceOk && checkActiveKey()) {
			if (!anim.GetBool ("OnMove") && !anim.GetBool ("OnStun")) {
				anim.Play (stateName);
				player.audioSource.PlayOneShot (voiceSound);
				anim.SetBool ("OnMove", true);
				anim.SetBool ("IgnoreGravity", true);
			}
			state = 0;
			anim.SetBool ("Combo" + stateName, true);
		}

	}

	//=========================================================================//
	bool checkActiveKey(){
		for (int i = 0; i < activeKey.Length; i++) {
			if (player.controller.GetButtonDown (activeKey [i])) {
				return true;
			}
		}
		return false;
	}
	void InvertControls(){
		for (int i = 0; i < sequenceKey.Length; i++) {
			if (player.direction == -1) {
				if (sequenceKey [i] == Button.BACK) {
					mappedKeys [i] = Button.FORWARD;
				}
				if (sequenceKey [i] == Button.FORWARD) {
					mappedKeys [i] = Button.BACK;
				}
			}
			if (player.direction == 1) {
				if (sequenceKey [i] == Button.BACK) {
					mappedKeys [i] = sequenceKey[i];
				}
				if (sequenceKey [i] == Button.FORWARD) {
					mappedKeys [i] = sequenceKey[i];
				}
			}
		}
	}
}
