using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static float GroundReference = 4;
	public int id;
	public Animator anim;
	public GameObject enemy;
	public int direction;
	public GameObject sprite;
	public Vector2 moveDirection;
	public float gravity;
	public float speed;
	public bool groundTouch;
	public static float time;
	public float life;
	public float gauge;

	void Start(){
		Player.time = 1;
		anim.SetInteger ("Id", id);
		this.tag = "P" + id.ToString ();
		Hit[] l = GetComponentsInChildren<Hit> ();
		foreach (Hit h in l) {
			h.tag = "P" + id.ToString ();
		}
	}

	void Update(){

		//BASIC MOVE GLOBAL CONFIGURATION ====================================================================================//
		anim.SetFloat ("Time", Player.time);
		this.transform.position += sprite.transform.localPosition;
		sprite.transform.localPosition = Vector2.zero;
		Vector2 myPos = this.transform.position;
		if (Physics2D.Linecast (myPos, myPos + Vector2.down*0.016f,  1 << LayerMask.NameToLayer("Ground"))) {
			anim.SetBool ("OnGround", true);
		}else {
			anim.SetBool ("OnGround", false);
		}

		//GROUND DETECTION CONFIGURATION ====================================================================================//
		if (anim.GetBool ("OnGround")) {
			this.transform.position = new Vector2 (this.transform.position.x, -GroundReference);
			if (enemy.transform.position.x > this.transform.position.x) {
				sprite.transform.localScale = new Vector2 (1, 1);
				direction = 1;
			} else {
				sprite.transform.localScale = new Vector2 (-1, 1);
				direction = -1;
			}
			if (groundTouch == false) {
				moveDirection = Vector2.zero;
				groundTouch = true;
			}
		}

		//DEFINE DIRECTION====================================================================================//
		if (!anim.GetBool ("OnGround")) {
			groundTouch = false;
		}
		anim.SetBool ("TouchGround", groundTouch);

		//CONFIGURE PHYSICS===================================================================================================//
		if (anim.GetBool ("OnGround")) {
			if (moveDirection.x != 0) {
				moveDirection.x -= Time.deltaTime * moveDirection.x*7;
				if (moveDirection.x <= 0.016f && moveDirection.x >= -0.016f) {
					moveDirection.x = 0;
				}
			}
			//moveDirection.y = 0;
		} else {
			moveDirection.y -= gravity * Time.deltaTime * Player.time;
		}
		if(anim.GetBool ("IgnoreGravity")){
			moveDirection = Vector2.zero;
		}
		this.transform.Translate (moveDirection*Time.deltaTime*Player.time);
	}
}
