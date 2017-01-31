using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour {

	public Character character;
	public Image face;
	public Image border;
	public List<Cursor> cursorList;

	void Start () {
		cursorList = new List<Cursor> ();
		if (character != null) {
			this.face.sprite = character.face;
		}
	}
	void Update(){
		if (cursorList.Count > 0) {
			border.color = new Color();	
			for (int i = 0; i < cursorList.Count; i++) {
				border.color += cursorList [i].color;
			}
		} else {
			border.color = Color.white;
		}
	}
}
