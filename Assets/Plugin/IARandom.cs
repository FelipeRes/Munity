using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARandom : Controller {

	public override bool GetButton(Button button){
		if (enable) {
			switch (button) {
			case Button.UP:
				return RandomState();
			case Button.BACK:
				return RandomState();
			case Button.FORWARD:
				return RandomState();
			case Button.DOWN: 
				return RandomState();
			case Button.A: 
				return RandomState();
			case Button.B: 
				return RandomState();
			case Button.C: 
				return RandomState();
			case Button.X: 
				return RandomState();
			case Button.Y: 
				return RandomState();
			case Button.Z: 
				return RandomState();
			default:
				return false;
			}
		}
		return false;
	}
	public override bool GetButtonDown(Button button){
		if (enable) {
			switch (button) {
			case Button.UP:
				return RandomState();
			case Button.BACK:
				return RandomState();
			case Button.FORWARD:
				return RandomState();
			case Button.DOWN: 
				return RandomState();
			case Button.A: 
				return RandomState();
			case Button.B: 
				return RandomState();
			case Button.C: 
				return RandomState();
			case Button.X: 
				return RandomState();
			case Button.Y: 
				return RandomState();
			case Button.Z: 
				return RandomState();
			default:
				return false;
			}
		}
		return false;
	}

	public bool RandomState(){
		if (Random.Range (0, 2) == 1) {
			return true;
		} else {
			return false;
		}
	}
}
