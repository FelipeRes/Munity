using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public KeyCode Up;
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Down;
	public KeyCode A;
	public KeyCode B;
	public KeyCode C;
	public KeyCode X;
	public KeyCode Y;
	public KeyCode Z;
	public Player player;

	public virtual bool GetButton(BUTTON button){
		if (button == BUTTON.UP) {
			return Input.GetKey (Up);
		}
		if (button == BUTTON.LEFT) {
			if (player.direction == 1) {
				return Input.GetKey (Left);
			} else {
				return Input.GetKey (Right);
			}
		}
		if (button == BUTTON.RIGHT) {
			if (player.direction == 1) {
				return Input.GetKey (Right);
			} else {
				return Input.GetKey (Left);
			}
		}
		if (button == BUTTON.DOWN) {
			return Input.GetKey (Down);
		}
		if (button == BUTTON.A) {
			return Input.GetKey (A);
		}
		if (button == BUTTON.B) {
			return Input.GetKey (B);
		}
		if (button == BUTTON.C) {
			return Input.GetKey (C);
		}
		if (button == BUTTON.X) {
			return Input.GetKey (X);
		}
		if (button == BUTTON.Y) {
			return Input.GetKey (Y);
		}
		if (button == BUTTON.Z) {
			return Input.GetKey (Z);
		}
		return false;
	}
	public virtual bool GetButtonDown(BUTTON button){
		if (button == BUTTON.UP) {
			return Input.GetKeyDown (Up);
		}
		if (button == BUTTON.LEFT) {
			if (player.direction == 1) {
				return Input.GetKeyDown (Left);
			} else {
				return Input.GetKeyDown (Right);
			}
		}
		if (button == BUTTON.RIGHT) {
			if (player.direction == 1) {
				return Input.GetKeyDown (Right);
			} else {
				return Input.GetKeyDown (Left);
			}
		}
		if (button == BUTTON.DOWN) {
			return Input.GetKeyDown (Down);
		}
		if (button == BUTTON.A) {
			return Input.GetKeyDown (A);
		}
		if (button == BUTTON.B) {
			return Input.GetKeyDown (B);
		}
		if (button == BUTTON.C) {
			return Input.GetKeyDown (C);
		}
		if (button == BUTTON.X) {
			return Input.GetKeyDown (X);
		}
		if (button == BUTTON.Y) {
			return Input.GetKeyDown (Y);
		}
		if (button == BUTTON.Z) {
			return Input.GetKeyDown (Z);
		}
		return false;
	}
}
