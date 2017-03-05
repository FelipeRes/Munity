using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Round round;
	//public Camera camera;
	public Player[] player = new Player[2];
	public float leftMargin;
	public float rightMargin;
	public float maxLeft;
	public float maxRight;
	void Start () {
		player[0] = round.player1;
		player[1] = round.player2;
	}

	void Update () {
		float cameraCenter = this.transform.position.x;
		float pos = 0;
		for (int i = 0; i < player.Length; i++) {
			if (player [i].transform.position.x < leftMargin + cameraCenter) {
				pos -= Mathf.Abs (leftMargin + cameraCenter - player [i].transform.position.x)/2;
			}
			if (player [i].transform.position.x > rightMargin + cameraCenter) {
				pos += Mathf.Abs (rightMargin + cameraCenter - player [i].transform.position.x)/2;
			}
		}
		this.transform.position += new Vector3 (pos, 0, 0);

		if (this.transform.position.x > maxRight) {
			this.transform.position = new Vector3(maxRight, this.transform.position.y, this.transform.position.z);
		}
		if (this.transform.position.x < maxLeft) {
			this.transform.position = new Vector3(maxLeft, this.transform.position.y, this.transform.position.z);
		}
	}
}
