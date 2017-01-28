using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

	public int Id;
	public Character character;
	public Controller contoller;

	public void OnDestroy () {
		Debug.Log ("Not Destroyer");
	}
}
