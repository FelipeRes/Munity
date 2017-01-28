using UnityEngine;
using System.Collections;

public class BasicMove : MonoBehaviour {

	public Animator anim;
	public Controller controller;
	public Button key;
	public string stateName;
	public Vector2 movement;

	void Start(){
		controller = this.GetComponent<Player> ().controller;
	}

	void Update () {
		if (controller.GetButton(key) && anim.GetBool ("OnGround") && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)) {
			Vector2 vetor = this.transform.position;
			this.transform.Translate (movement*0.16f*this.GetComponent<Player>().direction);
		} 
		anim.SetBool (stateName,controller.GetButton(key));
	}
}
