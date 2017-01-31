using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	public Controller controller;
	public Color color;
	public int pointer;
	public int lenghtList;
	public int numberOfColumms;

	void Update () {
		if (controller.GetButtonDown (Button.FORWARD)) {
			if (pointer >= lenghtList-1) {
				pointer = 0;
			} else {
				pointer++;
			}
		}
		if (controller.GetButtonDown (Button.BACK)) {
			if (pointer <= 0) {
				pointer = lenghtList-1;
			} else {
				pointer--;
			}
		}
		if (controller.GetButtonDown (Button.DOWN)) {
			pointer += numberOfColumms;
			if (pointer >= lenghtList) {
				pointer -= lenghtList;
			}
		}
		if (controller.GetButtonDown (Button.UP)) {
			pointer -= numberOfColumms;
			if (pointer < 0) {
				pointer += lenghtList;
			}
		}
	}
}
