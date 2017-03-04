using UnityEngine;
using System.Collections;

public class SimpleDamage : MonoBehaviour {

	private Animator anim;
	public GameObject guardParticle;
	public int hitCount;
	private float stunTimeCount;
	private float hitTimerCounter;
	private Player player;
	private Collider2D collider;

	void Start(){
		player = this.GetComponent<Player> ();
		anim = player.anim;
		collider = player.playerBox;
	}
	void Update(){
		StunTime ();
		TimeHitCount ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Hit> () != null) {
			Hit hit = coll.gameObject.GetComponent<Hit> ();
			if (hit.tag == this.tag) {
				return;
			}
			if (anim.GetBool ("OnGuard")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Overhead) {
					Blocked (coll, hit);
				} else {
					ApplyDamage(coll,hit);
				}
			} else if (anim.GetBool ("OnGuardDown")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Sweep) {
					Blocked (coll, hit);
				} else {
					ApplyDamage(coll,hit);
				}
			} else {
				ApplyDamage(coll,hit);
			}
		}
	}
	void Return(){
		Player.time = 1;
	}
	void Blocked(Collider2D coll, Hit hit){
		ShowHitEffect (coll, guardParticle);
		player.SimplePushCharacter (hit.recuo.x);
		if(player.anim.GetBool("OnWall") && hit.player.anim.GetBool("OnGround")){
			hit.player.SimplePushCharacter(hit.recuo.x*2);
		}
	}
	void ApplyDamage(Collider2D coll, Hit hit){
		Player.time = 0;
		Invoke ("Return", hit.stopTime);
		hitCount++;
		ShowHitEffect (coll, hit.hitEffect);
		player.life -= hit.damage;
		player.enemy.GetComponent<Player> ().gauge += hit.gauge;
		player.SetDirection ();
		if(player.anim.GetBool("OnWall") && hit.player.anim.GetBool("OnGround")){
			hit.player.SimplePushCharacter(hit.recuo.x);
		}
		if(player.anim.GetBool("OnGround")){
			player.PushCharacter(hit.recuo);
		}else{
			player.PushCharacter(hit.recuoNoAr);
		}anim.SetTrigger("Hit");
		if(anim.GetBool("OnGround")){
			if (hit.KnockDown) {
				anim.SetTrigger("KnockDown");
			} else {
				anim.SetTrigger("Hit");
			}
		}else{
			if (hit.airKnockDown) {
				anim.SetTrigger("AirKnockDown");
			} else {
				anim.SetTrigger("Hit");
			}
		}
		stunTimeCount = hit.stunTime;
		hitTimerCounter = hit.stunTime;
	}

	void ShowHitEffect(Collider2D coll, GameObject particle){
		float x = (coll.bounds.min.x + collider.bounds.max.x) / 2;
		float y = (coll.bounds.min.y + collider.bounds.max.y) / 2;
		Vector2 pos = new Vector2 (x,y);
		GameObject hitEffect = Instantiate (particle, pos, Quaternion.identity) as GameObject;
		if (this.GetComponent<Player> ().direction == 1) {
			hitEffect.transform.localScale=new Vector3(-1,1,1);
		}
		Destroy (hitEffect, 1);
	}
		
	void StunTime(){
		if (stunTimeCount <= 0) {
			stunTimeCount = 0;
			anim.SetBool ("OnStun", false);
		} else {
			stunTimeCount -= Time.deltaTime;
			anim.SetBool ("OnStun", true);
		}
	}

	void TimeHitCount(){
		if (hitTimerCounter <= 0) {
			hitTimerCounter = 0;
			hitCount = 0;
		} else {
			hitTimerCounter -= Time.deltaTime;
		}
	}
}
