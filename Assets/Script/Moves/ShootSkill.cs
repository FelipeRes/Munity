using UnityEngine;
using System.Collections;

public class ShootSkill : MonoBehaviour {

	public ProjectilHit projectil;
	public GameObject projectilObject;
	public bool active;
	public Player player;
	void Start(){
		projectilObject = projectil.gameObject;
	}
	void Update(){
		if (active && projectilObject != null) {
			Instantiate (projectilObject, this.transform.position, Quaternion.identity);
			projectil.direction = player.direction;
			Debug.Log ("Invoca");
			projectilObject = null;
		}
		if (!active) {
			projectilObject = projectil.gameObject;
		}
	}
}
