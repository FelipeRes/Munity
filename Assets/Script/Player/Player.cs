using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static float GroundReference = 4;
	public int id;
	public Animator anim;
	public GameObject wallSensor;
	public GameObject enemy;
	public GameObject playerBox;
	public int direction;
	public GameObject sprite;
	public Vector2 moveDirection;
	public float gravity;
	public float speed;
	public bool groundTouch;
	public static float time;
	public float life;
	public float gauge;

	public List<BoxCollider2D> colliderList;

	void Start(){
		Player.time = 1;
		anim.SetInteger ("Id", id);
		this.tag = "P" + id.ToString ();
		Hit[] l = GetComponentsInChildren<Hit> ();
		foreach (Hit h in l) {
			h.tag = "P" + id.ToString ();
		}
		playerBox.tag = "P" + id.ToString ();
		BoxCollider2D[] lista = sprite.GetComponentsInChildren<BoxCollider2D> ();
		for(int i = 0; i<lista.Length; i++){
			if (lista [i].gameObject.layer == 8) {
				colliderList.Add (lista [i]);
			}
		}
	}

	void Update(){

		//BASIC MOVE GLOBAL CONFIGURATION ====================================================================================//
		anim.SetFloat ("Time", Player.time);
		this.transform.position += sprite.transform.localPosition;
		sprite.transform.localPosition = Vector2.zero;
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

	//=========================================================================================//
	public void PushCharacter(Hit hit){
		Vector2 vetor = new Vector2 ();
		Vector2 airVetor = new Vector2 ();
		vetor = hit.recuo;
		airVetor = hit.recuoNoAr;
		vetor.x *= -this.GetComponent<Player> ().direction;
		airVetor.x *= -this.GetComponent<Player> ().direction;
		if (anim.GetBool ("OnGround")) {
			this.GetComponent<Player> ().moveDirection = vetor;
		} else {
			this.GetComponent<Player> ().moveDirection = airVetor;
		}
		this.transform.Translate (this.GetComponent<Player> ().moveDirection * Time.deltaTime);
	}
	public void SimplePushCharacter(Hit hit){
		Vector2 vetor = new Vector2 ();
		vetor = hit.recuo;
		vetor.x *= -this.GetComponent<Player> ().direction;
		vetor.y = 0;
		this.GetComponent<Player> ().moveDirection = vetor;
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
