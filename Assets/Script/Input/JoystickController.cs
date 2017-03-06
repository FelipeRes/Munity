using UnityEngine;
using System.Collections;

public class JoystickController : Controller {

	public float sensibilty;
	public override bool GetButton(Button button){
		if (enable) {
			if (button == Button.UP) {
				if (Input.GetAxis ("AXISY") >= sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.DOWN) {
				if (Input.GetAxis ("AXISY") <= -sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.FORWARD) {
				if (Input.GetAxis ("AXISX") >= sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.BACK) {
				if (Input.GetAxis ("AXISX") <= -sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.A) {
				return Input.GetButton ("A");
			}
			if (button == Button.B) {
				return Input.GetButton ("B");
			}
			if (button == Button.C) {
				return Input.GetButton ("C");
			}
			if (button == Button.X) {
				return Input.GetButton ("X");
			}
			if (button == Button.Y) {
				return Input.GetButton ("Y");
			}
			if (button == Button.Z) {
				return Input.GetButton ("Z");
			}
		}
		return false;
	}
	public override bool GetButtonDown(Button button){
		if (enable) {
			if (button == Button.UP) {
				if (Input.GetAxis ("AXISY") >= sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.DOWN) {
				if (Input.GetAxis ("AXISY") <= -sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.FORWARD) {
				if (Input.GetAxis ("AXISX") >= sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.BACK) {
				if (Input.GetAxis ("AXISX") <= -sensibilty) {
					return true;
				} else {
					return false;
				}
			}
			if (button == Button.A) {
				return Input.GetButtonDown ("A");
			}
			if (button == Button.B) {
				return Input.GetButtonDown ("B");
			}
			if (button == Button.C) {
				return Input.GetButtonDown ("C");
			}
			if (button == Button.X) {
				return Input.GetButtonDown ("X");
			}
			if (button == Button.Y) {
				return Input.GetButtonDown ("Y");
			}
			if (button == Button.Z) {
				return Input.GetButtonDown ("Z");
			}
		}
		return false;
	}
}
