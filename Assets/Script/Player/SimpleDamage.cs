using UnityEngine;
using System.Collections;

public class SimpleDamage : MonoBehaviour {

	public Animator anim;
	public GameObject guardParticle;
	public int HitCount;
	public Player player;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Hit> () != null) {
			Hit hit = coll.gameObject.GetComponent<Hit> ();
			if (hit.tag == this.tag) {
				return;
			}
			if (anim.GetBool ("OnGuard")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Overhead) {
					ShowHitEffect (coll, guardParticle);
				} else {
					ApplyDamage(coll,hit);
				}
			} else if (anim.GetBool ("OnGuardDown")) {
				if (hit.height == SkillHeight.Simple || hit.height == SkillHeight.Sweep) {
					ShowHitEffect (coll, guardParticle);
				} else {
					ApplyDamage(coll,hit);
				}
			} else {
				ApplyDamage(coll,hit);
			}
			Player.time = 0;
			Invoke ("Return", 0.1f);
		}
	}

	void Return(){
		Player.time = 1;
	}
	void ApplyDamage(Collider2D coll, Hit hit){
		player.life -= hit.damage;
		player.enemy.GetComponent<Player> ().gauge += hit.gauge;
		if (anim.GetBool ("OnStun")) {
			HitCount++;
			CancelInvoke ("hitCount");
			Invoke ("hitCount", 2);
		} else {
			HitCount = 1;
		}
		ShowHitEffect (coll, hit.hitEffect);
		PushCharacter(hit);
		if (hit.derrubar) {
			anim.Play ("Derrubar");
		} else {
			anim.SetTrigger ("Hit");
		}
		anim.SetBool ("OnStun", true);
		CancelInvoke ("stunReturn");
		Invoke ("stunReturn", hit.stunTime);
	}

	void ShowHitEffect(Collider2D coll, GameObject particle){
		Vector2 pos = new Vector2 ();
		pos = coll.transform.position;
		if (this.GetComponent<Player> ().direction == 1) {
			pos.x += -coll.offset.x;
			pos.y += coll.offset.y;
		} else {
			pos += coll.offset;
		}
		GameObject hitEffect = Instantiate (particle, pos, Quaternion.identity) as GameObject;
		Destroy (hitEffect, 1);
	}

	void PushCharacter(Hit hit){
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
	void stunReturn(){
		anim.SetBool ("OnStun", false);
	}
	void hitCount(){
		HitCount = 0;
	}
}
