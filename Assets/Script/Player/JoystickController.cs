using UnityEngine;
using System.Collections;

public class JoystickController : Controller {

	void Start(){
		player = this.GetComponent<Player> ();
	}

	public override bool GetButton(Button button){
		if (button == Button.UP) {
			if (Input.GetAxis ("Vertical") == 1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == Button.LEFT) {
			if (player.direction == 1) {
				if (Input.GetAxis ("Horizontal") == -1) {
					return true;
				} else {
					return false;
				}	
			} else {
				if (Input.GetAxis ("Horizontal") == 1) {
					return true;
				} else {
					return false;
				}
			}
		}
		if (button == Button.RIGHT) {
			if (player.direction == 1) {
				if (Input.GetAxis ("Horizontal") == 1) {
					return true;
				} else {
					return false;
				}
			} else {
				if (Input.GetAxis ("Horizontal") == -1) {
					return true;
				} else {
					return false;
				}
			}
		}
		if (button == Button.DOWN) {
			if (Input.GetAxis ("Vertical") == -1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == Button.A) {
			return Input.GetKey (A);
		}
		if (button == Button.B) {
			return Input.GetKey (B);
		}
		if (button == Button.C) {
			return Input.GetKey (C);
		}
		if (button == Button.X) {
			return Input.GetKey (X);
		}
		if (button == Button.Y) {
			return Input.GetKey (Y);
		}
		if (button == Button.Z) {
			return Input.GetKey (Z);
		}
		return false;
	}
	public override bool GetButtonDown(Button button){
		if (button == Button.UP) {
			if (Input.GetAxis ("Vertical") == 1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == Button.LEFT) {
			if (player.direction == 1) {
				if (Input.GetAxis ("Horizontal") == -1) {
					return true;
				} else {
					return false;
				}	
			} else {
				if (Input.GetAxis ("Horizontal") == 1) {
					return true;
				} else {
					return false;
				}
			}
		}
		if (button == Button.RIGHT) {
			if (player.direction == 1) {
				if (Input.GetAxis ("Horizontal") == 1) {
					return true;
				} else {
					return false;
				}
			} else {
				if (Input.GetAxis ("Horizontal") == -1) {
					return true;
				} else {
					return false;
				}
			}
		}
		if (button == Button.DOWN) {
			if (Input.GetAxis ("Vertical") == -1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == Button.A) {
			return Input.GetKeyDown (A);
		}
		if (button == Button.B) {
			return Input.GetKeyDown (B);
		}
		if (button == Button.C) {
			return Input.GetKeyDown (C);
		}
		if (button == Button.X) {
			return Input.GetKeyDown (X);
		}
		if (button == Button.Y) {
			return Input.GetKeyDown (Y);
		}
		if (button == Button.Z) {
			return Input.GetKeyDown (Z);
		}
		return false;
	}
}
