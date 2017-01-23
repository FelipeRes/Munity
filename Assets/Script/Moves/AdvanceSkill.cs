using UnityEngine;
using System.Collections;

public class AdvanceSkill : MonoBehaviour {

	public Animator anim;
	public SkillType trype;
	public Controller controller;
	public Button[] key;
	public string stateName;
	public bool ignoreGravity;
	private bool changeState;
	public bool OnAir;
	public int state;
	public float time;

	void Start(){
		controller = this.GetComponent<Player> ().controller;
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

		time = (time > 0) ? time - Time.deltaTime : 0;
		if (time <= 0) state = 0;

		/*
		if (time > 0) {
			time -= Time.deltaTime;
		} else {
			time = 0;
			state = 0;
		}
		*/

		changeState = AssemblyCSharp.MoveUtils.verifyStateChange (anim, stateName, changeState);

		/*
		bool inState = anim.GetCurrentAnimatorStateInfo (0).IsName (stateName);

		if (inState && changeState == false) {
			anim.SetBool ("OnMove", true);
			anim.SetBool ("IgnoreGravity", true);
			changeState = true;
		}

		if (!inState && changeState == true) {
			anim.SetBool ("OnMove", false);
			anim.SetBool ("IgnoreGravity", false);
			changeState = false;
		}
		*/
	}
}
