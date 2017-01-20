using UnityEngine;
using System.Collections;

public class ProjectilHit : MonoBehaviour {

	public Hit hit;
	public float Velocity;
	public int direction;
	void Start(){
		hit.player.colliderList.Add (this.GetComponentInChildren<BoxCollider2D>());	
	}
	void Update () {
		this.transform.localScale = new Vector2 (1 * direction, 1);
		this.transform.Translate (Vector2.right * Velocity * Time.deltaTime * direction);
	}
	void OnTriggerEnter2D(Collider2D coll){
		hit.player.colliderList.Remove (this.GetComponentInChildren<BoxCollider2D>());	
		if (hit.tag != coll.tag) {
			Destroy (this.gameObject);
		}
		if (coll.gameObject.layer == LayerMask.NameToLayer("Wall")) {
			Destroy (this.gameObject);
		}
	}
}
