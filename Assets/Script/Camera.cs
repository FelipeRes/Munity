using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	void Update () {
		float posx = (Player1.transform.position.x + Player2.transform.position.x) / 2;
		this.transform.position = new Vector3 (posx, 0,-10);
	}
}
