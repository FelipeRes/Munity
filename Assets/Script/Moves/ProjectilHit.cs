using UnityEngine;
using System.Collections;

public class ProjectilHit : MonoBehaviour {

	public Hit hit;
	public float Velocity;
	public int direction;
	void Update () {
		this.transform.localScale = new Vector2 (1 * direction, 1);
		this.transform.Translate (Vector2.right * Velocity * Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (hit.tag != coll.tag) {
			Destroy (this.gameObject);
		}
	}
}
