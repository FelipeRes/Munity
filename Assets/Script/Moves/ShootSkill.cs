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
			GameObject proj =  Instantiate (projectilObject, this.transform.position, Quaternion.identity) as GameObject;
			proj.GetComponent<ProjectilHit> ().direction = player.direction;
			proj.GetComponent<ProjectilHit> ().hit.gameObject.tag = player.tag;
			proj.GetComponent<ProjectilHit> ().hit.player = player;
			projectilObject = null;
		}
		if (!active) {
			projectilObject = projectil.gameObject;
		}
	}
}
