using UnityEngine;
using System.Collections;

public class BasicSkill : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public BUTTON key;
	public string stateName;
	public bool ignoreGravity;
	public SkillType type;
	public SkillHeight height;
	private bool changeState;

	void Start(){
		controller = this.GetComponent<Controller> ();
	}

	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (stateName) && changeState == false) {
			anim.SetBool ("OnMove", true);
			changeState = true;
		}
		if (changeState == true && !anim.GetCurrentAnimatorStateInfo (0).IsName (stateName)) {
			anim.SetBool ("OnMove", false);
			changeState = false;
		}
		if (type == SkillType.Default) {
			if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == false) {
				anim.SetBool ("Combo"+stateName, controller.GetButtonDown(key));
				if (controller.GetButtonDown(key) && !anim.GetBool ("OnMove")) {
					anim.Play (stateName);
				}
			}
		}
		if (type == SkillType.OnAir) {
			if (anim.GetBool ("OnGround") == false && anim.GetBool ("Crounch") == false) {
				anim.SetBool ("Combo"+stateName, controller.GetButtonDown(key));
				if (controller.GetButtonDown(key) && !anim.GetBool ("OnMove")) {
					anim.Play (stateName);
				}
			}
		}
		if (type == SkillType.Crounch) {
			if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == true) {
				anim.SetBool ("Combo"+stateName,controller.GetButtonDown(key));
				if (controller.GetButtonDown(key) && !anim.GetBool ("OnMove")) {
					anim.Play (stateName);
				}
			}
		}
	}
}
