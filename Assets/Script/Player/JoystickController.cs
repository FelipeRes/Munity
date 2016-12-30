using UnityEngine;
using System.Collections;

public class JoystickController : Controller {

	void Start(){
		player = this.GetComponent<Player> ();
	}

	public override bool GetButton(BUTTON button){
		if (button == BUTTON.UP) {
			if (Input.GetAxis ("Vertical") == 1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == BUTTON.LEFT) {
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
		if (button == BUTTON.RIGHT) {
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
		if (button == BUTTON.DOWN) {
			if (Input.GetAxis ("Vertical") == -1) {
				return true;
			} else {
				return false;
			}
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
	public override bool GetButtonDown(BUTTON button){
		if (button == BUTTON.UP) {
			if (Input.GetAxis ("Vertical") == 1) {
				return true;
			} else {
				return false;
			}
		}
		if (button == BUTTON.LEFT) {
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
		if (button == BUTTON.RIGHT) {
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
		if (button == BUTTON.DOWN) {
			if (Input.GetAxis ("Vertical") == -1) {
				return true;
			} else {
				return false;
			}
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
