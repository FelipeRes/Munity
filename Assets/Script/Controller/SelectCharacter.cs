using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour {

	public PlayerInfo playerInfoBase;
	public Controller controller1;
	public Controller controller2;
	public Image player1Face;
	public Image player2Face;
	public Cursor cursorObject;
	public Cursor cursor1;
	public Cursor cursor2;
	public int numberOfColumms;
	public CharacterBox[] characterList; 

	void Start () {
		controller1.enable = true;
		controller2.enable = true;
	}

	void Update () {
		if (cursor1 == null) {
			if (controller1.GetButtonDown (Button.A)) {
				cursor1 = Instantiate (cursorObject, this.transform) as Cursor;
				cursor1.controller = controller1;
				cursor1.lenghtList = characterList.Length;
				cursor1.numberOfColumms = numberOfColumms;
			}
		} else {
			player1Face.sprite = characterList [cursor1.pointer].face.sprite;
			if (controller1.GetButtonDown (Button.A)) {
				controller1.enable = false;
				MainController.Instance.StartNewPlayer (characterList [cursor1.pointer].character, controller1,playerInfoBase);
			}
		}
		if (cursor2 == null) {
			if (controller2.GetButtonDown (Button.A)) {
				cursor2 = Instantiate (cursorObject, this.transform) as Cursor;
				cursor2.controller = controller2;
				cursor2.lenghtList = characterList.Length;
				cursor2.numberOfColumms = numberOfColumms;
			}
		} else {
			player2Face.sprite = characterList [cursor2.pointer].face.sprite;
			if (controller2.GetButtonDown (Button.A)) {
				controller2.enable = false;
				MainController.Instance.StartNewPlayer (characterList [cursor2.pointer].character, controller2,playerInfoBase);
			}
		}
		if (MainController.Instance.playerInfos.Count >= 2) {
			Application.LoadLevel (0);
		}
	}
}
