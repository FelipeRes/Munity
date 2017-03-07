using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPull : MonoBehaviour {

	public Round round;
	public List<string> myStates = new List<string>();
	public List<string> enemyStates = new List<string>();
	private string query;
	// Use this for initialization
	void Start () {
		round = this.GetComponent<Round> ();
		RuntimeAnimatorController overrideAnim = (RuntimeAnimatorController)round.player1.anim.runtimeAnimatorController;
		for (int i = 0; i < overrideAnim.animationClips.Length; i++) {
			myStates.Add (overrideAnim.animationClips [i].name);
		}
		RuntimeAnimatorController overrideAnim2 = (RuntimeAnimatorController)round.player2.anim.runtimeAnimatorController;
		for (int i = 0; i < overrideAnim2.animationClips.Length; i++) {
			enemyStates.Add (overrideAnim2.animationClips [i].name);
		}
	}

	string GetState(Animator anim){
		for (int i = 0; i < myStates.Count; i++) {
			if(anim.GetCurrentAnimatorStateInfo(0).IsName(myStates[i])){
				return myStates [i];
			}
		}
		return "none";
	}
	public string GetData(){
		int distance_x = (int)(round.player1.transform.position.x - round.player2.transform.position.x);
		int distance_y = (int)(round.player1.transform.position.y - round.player2.transform.position.y);
		int button_up = 0;
		if (round.player1.controller.GetButton (Button.UP)) {
			button_up = 1;
		}
		int button_down = 0;
		if (round.player1.controller.GetButton (Button.DOWN)) {
			button_down = 1;
		}
		int button_left = 0;
		if (round.player1.controller.GetButton (Button.FORWARD)) {
			button_left = 1;
		}
		int button_right = 0;
		if (round.player1.controller.GetButton (Button.BACK)) {
			button_right = 1;
		}
		int button_a = 0;
		if (round.player1.controller.GetButton (Button.A)) {
			button_a = 1;
		}
		int button_b = 0;
		if (round.player1.controller.GetButton (Button.B)) {
			button_b = 1;
		}
		int button_c = 0;
		if (round.player1.controller.GetButton (Button.C)) {
			button_c = 1;
		}

		query = "Insert into info values(" + distance_x + "," + distance_y + "," + button_up + "," + button_down + "," + button_left + "," + button_right + "," + button_a + "," + button_b + "," + button_c +");\n";
		return query;
	}
}
