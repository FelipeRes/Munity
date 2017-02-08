using UnityEngine;
using System.Collections;

public class SimpleDamage : MonoBehaviour {

	private Animator anim;
	public GameObject guardParticle;
	public int hitCount;
	public Player player;
	public Collider2D collider;

	void Start(){
		player = this.GetComponent<Player> ();
		anim = player.anim;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Hit> () != null) {
			Hit hit = coll.gameObject.GetComponent<Hit> ();
			if (hit.tag == this.tag) {
				return;
			}
			if (anim.GetBool ("OnGuard")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Overhead) {
					ShowHitEffect (coll, guardParticle);
					player.PushCharacter(hit);
					if(player.anim.GetBool("OnWall") && hit.player.anim.GetBool("OnGround")){
						hit.player.PushCharacter(hit);
					}
				} else {
					ApplyDamage(coll,hit);
				}
			} else if (anim.GetBool ("OnGuardDown")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Sweep) {
					ShowHitEffect (coll, guardParticle);
					player.PushCharacter(hit);
					if(player.anim.GetBool("OnWall") && hit.player.anim.GetBool("OnGround")){
						hit.player.PushCharacter(hit);
					}
				} else {
					ApplyDamage(coll,hit);
				}
			} else {
				ApplyDamage(coll,hit);
			}
			Player.time = 0;
			Invoke ("Return", hit.stopTime);
		}
	}

	void Return(){
		Player.time = 1;
	}
	void ApplyDamage(Collider2D coll, Hit hit){
		HitCount ();
		ShowHitEffect (coll, hit.hitEffect);
		player.life -= hit.damage;
		player.enemy.GetComponent<Player> ().gauge += hit.gauge;
		if(player.anim.GetBool("OnWall") && hit.player.anim.GetBool("OnGround")){
			hit.player.SimplePushCharacter(hit);
		}
		player.PushCharacter(hit);
		if (hit.KnockDown) {
			anim.SetTrigger("KnockDown");
		} else {
			anim.SetTrigger("Hit");
		}
		anim.SetBool ("OnStun", true);
		CancelInvoke ("stunReturn");
		Invoke ("stunReturn", hit.stunTime);
	}

	void ShowHitEffect(Collider2D coll, GameObject particle){
		float x = (coll.bounds.center.x + collider.bounds.center.x) / 2;
		float y = (coll.bounds.center.y + collider.bounds.center.y) / 2;
		Vector2 pos = new Vector2 (x,y);
		GameObject hitEffect = Instantiate (particle, pos, Quaternion.identity) as GameObject;
		if (this.GetComponent<Player> ().direction == 1) {
			hitEffect.transform.localScale=new Vector3(-1,1,1);
		}
		Destroy (hitEffect, 1);
	}
		
	void stunReturn(){
		anim.SetBool ("OnStun", false);
	}


	void HitCount(){
		if (anim.GetBool ("OnStun")) {
			hitCount++;
			CancelInvoke ("CloseHitCount");
			Invoke ("CloseHitCount", 2);
		} else {
			hitCount = 1;
		}
	}
	void CloseHitCount(){
		hitCount = 0;
	}
}
