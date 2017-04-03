using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public int id;
	public Animator anim;
	public GameObject wallSensor;
	public GameObject enemy;
	public Collider2D playerBox;
	public GameObject visual;
	public Controller controller;
	public int direction;
	public Vector2 moveDirection;
	public float gravity;
	public float speed;
	public bool groundTouch;
	public static float time;
	public float life;
	public float gauge;
	public AudioSource audioSource;
	public AudioClip groundTouchSound;

	public List<BoxCollider2D> colliderList;

	void Start(){
		Player.time = 1;
		anim.SetInteger ("Id", id);
		this.tag = "P" + id.ToString ();
		Hit[] l = GetComponentsInChildren<Hit> ();
		foreach (Hit h in l) {
			h.tag = "P" + id.ToString ();
		}
		playerBox.gameObject.tag = "P" + id.ToString ();
		BoxCollider2D[] lista = visual.GetComponentsInChildren<BoxCollider2D> ();
		for(int i = 0; i<lista.Length; i++){
			if (lista [i].gameObject.layer == 8) {
				colliderList.Add (lista [i]);
			}
		}
	}

	void Update(){
		//BASIC MOVE GLOBAL CONFIGURATION ====================================================================================//
		anim.SetFloat ("Time", Player.time);
		this.transform.position += visual.transform.localPosition;
		visual.transform.localPosition = Vector2.zero;
		Vector2 myPos = this.transform.position;
		Vector2 myPosWall = wallSensor.transform.position;
		if (Physics2D.Linecast (myPos, myPos + Vector2.down*0.016f,  1 << LayerMask.NameToLayer("Ground"))) {
			anim.SetBool ("OnGround", true);
		}else {
			anim.SetBool ("OnGround", false);
		}
		if (Physics2D.Linecast (myPosWall, myPosWall + Vector2.left*0.016f,  1 << LayerMask.NameToLayer("Wall"))) {
			anim.SetBool ("OnWall", true);
		}else {
			anim.SetBool ("OnWall", false);
		}

		//GROUND DETECTION CONFIGURATION ====================================================================================//
		if (anim.GetBool ("OnGround")) {
			this.transform.position = new Vector2 (this.transform.position.x, 0);
			SetDirection ();
			if (groundTouch == false) {
				if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("AirHit")) {
					moveDirection.x = 0;
				}
				audioSource.PlayOneShot (groundTouchSound);
				moveDirection.y = 0;
				groundTouch = true;
			}
		}

		//DEFINE DIRECTION====================================================================================//
		if (!anim.GetBool ("OnGround")) {
			groundTouch = false;
		}
		anim.SetBool ("TouchGround", groundTouch);
		//CONFIGURE PHYSICS===================================================================================================//
		if (anim.GetBool("OnGround")) {
			if (moveDirection.x != 0) {
				moveDirection.x -= Time.deltaTime * moveDirection.x * Global.PushCharacterFactor;
				if (moveDirection.x <= 0.016f && moveDirection.x >= -0.016f) {
					moveDirection.x = 0;
				}
			}
		}
		if (!anim.GetBool ("OnGround")) {
			moveDirection.y -= gravity * Time.deltaTime * Player.time;
		}
		if(anim.GetBool ("IgnoreGravity")){
			moveDirection = Vector2.zero;
		}
		this.transform.Translate (moveDirection*Time.deltaTime*Player.time);
	}

	//=========================================================================================//
	public void SetDirection(){
		if (!anim.GetBool ("IgnoreGravity")) {
			if (enemy.transform.position.x > this.transform.position.x) {
				visual.transform.localScale = new Vector3 (1, 1, 1);
				direction = 1;
			} else {
				visual.transform.localScale = new Vector3 (-1, 1, 1);
				direction = -1;
			}
		}
	}
	public void PushCharacter(Vector2 vector){
		Debug.Log (vector);
		vector.x *= -this.GetComponent<Player> ().direction;
		this.GetComponent<Player> ().moveDirection = vector;
		this.transform.Translate (this.GetComponent<Player> ().moveDirection * Time.deltaTime);
	}
	public void SimplePushCharacter(float force){
		force *= -this.GetComponent<Player> ().direction;
		this.GetComponent<Player> ().moveDirection.x = force;
		this.transform.Translate (this.GetComponent<Player> ().moveDirection * Time.deltaTime);
	}
	public bool CheckMove(){
		for (int i = 0; i < colliderList.Count; i++) {
			if (colliderList [i].isActiveAndEnabled) {
				return true;
			}
		}
		return false;
	}
}
