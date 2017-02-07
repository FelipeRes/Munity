using UnityEngine;
using System.Collections;

public class BasicSkill : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public Button key;
	public string stateName;
	public bool ignoreGravity;
	public SkillType type;
	private MoveState moveState;

	void Start(){
		controller = this.GetComponent<Player> ().controller;
		moveState = new MoveState (anim, stateName);
	}

	void Update () {
		moveState.ManageState ();
		if (!anim.GetBool ("OnGuard") && !anim.GetBool ("OnGuardDown")) {
			if (type == SkillType.Default && !anim.GetBool ("OnStun")) {
				if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == false) {
					anim.SetBool ("Combo" + stateName, controller.GetButtonDown (key));
					if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove") && !anim.GetBool ("Jump")) {
						anim.Play (stateName);
						Debug.Log ("Soco");
					}
				}
			}
			if (type == SkillType.OnAir && !anim.GetBool ("OnStun")) {
				if (anim.GetBool ("OnGround") == false && anim.GetBool ("Crounch") == false) {
					anim.SetBool ("Combo" + stateName, controller.GetButtonDown (key));
					if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove")) {
						anim.Play (stateName);
					}
				}
			}
			if (type == SkillType.Crounch && !anim.GetBool ("OnStun")) {
				if (anim.GetBool ("OnGround") == true && anim.GetBool ("Crounch") == true) {
					anim.SetBool ("Combo" + stateName, controller.GetButtonDown (key));
					if (controller.GetButtonDown (key) && !anim.GetBool ("OnMove")) {
						anim.Play (stateName);
					}
				}
			}
		}
	}
}
