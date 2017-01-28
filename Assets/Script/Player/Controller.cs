using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public bool enable;
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

	public virtual bool GetButton(Button button){
		if (enable) {
			switch (button) {
				case Button.UP:
					return Input.GetKey (Up);
				case Button.LEFT:
					return (player.direction == 1) ? Input.GetKey (Left) : Input.GetKey (Right);
				case Button.RIGHT:
					return (player.direction == 1) ? Input.GetKey (Right) : Input.GetKey (Left);
				case Button.DOWN: 
					return Input.GetKey (Down);
				case Button.A: 
					return Input.GetKey (A);
				case Button.B: 
					return Input.GetKey (B);
				case Button.C: 
					return Input.GetKey (C);
				case Button.X: 
					return Input.GetKey (X);
				case Button.Y: 
					return Input.GetKey (Y);
				case Button.Z: 
					return Input.GetKey (Z);
				default:
					return false;
			}
		}
		return false;
	}
	public virtual bool GetButtonDown(Button button){
		if (enable) {
			switch (button) {
				case Button.UP:
					return Input.GetKeyDown (Up);
				case Button.LEFT:
					return (player.direction == 1) ? Input.GetKeyDown (Left) : Input.GetKeyDown (Right);
				case Button.RIGHT:
					return (player.direction == 1) ? Input.GetKeyDown (Right) : Input.GetKeyDown (Left);
				case Button.DOWN: 
					return Input.GetKeyDown (Down);
				case Button.A: 
					return Input.GetKeyDown (A);
				case Button.B: 
					return Input.GetKeyDown (B);
				case Button.C: 
					return Input.GetKeyDown (C);
				case Button.X: 
					return Input.GetKeyDown (X);
				case Button.Y: 
					return Input.GetKeyDown (Y);
				case Button.Z: 
					return Input.GetKeyDown (Z);
				default:
					return false;
			}
		}
		return false;
	}
}
