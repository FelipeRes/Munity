using UnityEngine;
using System.Collections;

public class ProjectilHit : MonoBehaviour {

	public Hit hit;
	public float Velocity;
	public int direction;
	void Update () {
		this.transform.Translate (Vector2.right * Velocity * Time.deltaTime*direction);
	}
	void OnTriggerEnter2D(Collider2D coll){
		Destroy (this.gameObject);
	}
}
