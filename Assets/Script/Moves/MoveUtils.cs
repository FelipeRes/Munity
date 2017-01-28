using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MoveUtils
	{
		public MoveUtils (){}

		public static bool verifyStateChange(Animator anim, String stateName, bool changeState){

			if (anim.GetCurrentAnimatorStateInfo (0).IsName (stateName) && changeState == false) {
				anim.SetBool ("OnMove", true);
				anim.SetBool ("IgnoreGravity", true);
				changeState = true;
			}

			if (!anim.GetCurrentAnimatorStateInfo (0).IsName (stateName) && changeState == true) {
				anim.SetBool ("OnMove", false);
				anim.SetBool ("IgnoreGravity", false);
				changeState = false;
			}

			return changeState;
		}


	}
}

