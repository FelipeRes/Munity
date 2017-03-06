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
	string GetButtons(Controller controller){
		int button = 0;
		if (controller.GetButton (Button.UP)) {
			button += 1000000000;
		}
		if (controller.GetButton (Button.DOWN)) {
			button += 100000000;
		}
		if (controller.GetButton (Button.FORWARD)) {
			button += 10000000;
		}
		if (controller.GetButton (Button.BACK)) {
			button += 1000000;
		}
		if (controller.GetButton (Button.A)) {
			button += 100000;
		}
		if (controller.GetButton (Button.B)) {
			button += 10000;
		}
		if (controller.GetButton (Button.C)) {
			button += 1000;
		}
		if (controller.GetButton (Button.X)) {
			button += 100;
		}
		if (controller.GetButton (Button.Y)) {
			button += 10;
		}
		if (controller.GetButton (Button.Z)) {
			button += 1;
		}
		return button.ToString ();
	}
	public string GetData(){
		int distance_x = (int)(round.player1.transform.position.x - round.player2.transform.position.x);
		int distance_y = (int)(round.player1.transform.position.y - round.player2.transform.position.y);
		float life = round.player1.life/ round.player2.life;
		string meuEstado = GetState(round.player1.anim);
		string estadoInimigo = GetState(round.player2.anim);
		string botoes = GetButtons(round.player1.controller);
		query = "Insert into info values(" + distance_x + "," + distance_y + "," + life + ",'" + meuEstado + "','" + estadoInimigo + "','" + botoes + "');\n";
		return query;
	}
}
