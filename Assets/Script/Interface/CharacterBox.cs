using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour {

	public Character character;
	public Image face;

	void Start () {
		this.face.sprite = character.face;
	}
}
