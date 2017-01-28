using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {

	public PlayerInfo player1;
	public Controller controller1;
	public int cursor1;
	public int numberOfColumms;
	public CharacterBox[] characterList; 

	void Start () {
		cursor1 = 0;
		controller1.enable = true;
		//player1 = MainController.Instance.StartNewPlayer();
		//player1.contoller = controller1;
		//Debug.Log (player1.Id);
		//Cursor cursor1 = Instantiate (cursorObject1, this.transform.position, Quaternion.identity);
		//cursor1.transform.parent = this.gameObject.transform;
	}

	void Update () {
		if (controller1.GetButtonDown (Button.RIGHT)) {
			if (cursor1 > characterList.Length) {
				cursor1 = 0;
			} else {
				cursor1++;
			}
		}
		if (controller1.GetButtonDown (Button.LEFT)) {
			if (cursor1 < 0) {
				cursor1 = characterList.Length;
			} else {
				cursor1--;
			}
		}
	}
}
