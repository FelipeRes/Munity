using UnityEngine;
using System.Collections;

public class SimpleDamage : MonoBehaviour {

	public Animator anim;
	public GameObject guardParticle;
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.GetComponent<Hit> () != null && !anim.GetBool ("OnGuard")) {
			Hit hit = coll.gameObject.GetComponent<Hit> ();
			Vector2 pos = new Vector2 ();
			pos = coll.transform.position;
			if (this.GetComponent<Player> ().direction == 1) {
				pos.x += -coll.offset.x;
				pos.y += coll.offset.y;
			} else {
				pos += coll.offset;
			}
			GameObject hitEffect = Instantiate (hit.hitEffect, pos, Quaternion.identity) as GameObject;
			Destroy (hitEffect, 1);
			if (hit.derrubar) {
				anim.Play ("Derrubar");
			} else {
				anim.SetTrigger ("Hit");
			}
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
			Player.time = 0;
			Invoke ("Return", 0.1f);
		} else if(coll.gameObject.GetComponent<Hit> () != null && anim.GetBool ("OnGuard")){
			Vector2 pos = new Vector2 ();
			pos = coll.transform.position;
			if (this.GetComponent<Player> ().direction == 1) {
				pos.x += -coll.offset.x;
				pos.y += coll.offset.y;
			} else {
				pos += coll.offset;
			}
			GameObject hitEffect = Instantiate (guardParticle, pos, Quaternion.identity) as GameObject;
			Destroy (hitEffect, 1);
		}
	}
	void Return(){
		Player.time = 1;
	}
}
