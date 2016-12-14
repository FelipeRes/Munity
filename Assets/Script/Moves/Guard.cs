using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public Animator animator;
	public Animator enemyAnimator;
	public Controller controller;

	void Update () {
		if (enemyAnimator.GetBool ("OnMove") && controller.GetButton (BUTTON.LEFT)) {
			animator.SetBool ("OnGuard", true);
		} else {
			animator.SetBool ("OnGuard", false);
		}
	
	}
}
