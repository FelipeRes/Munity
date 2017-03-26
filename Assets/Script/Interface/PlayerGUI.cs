using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGUI : MonoBehaviour {

	public Player player;
	public Bar lifeBar;
	public Bar gauge;
	public Bar guardBreak;
	public float lifeFactor;
	public float gaugeFactor;
	public Text hitCount;

	void Update () {
		lifeBar.value = player.life / Global.LifeValue;
		guardBreak.value = player.GetComponent<Damage> ().guardBreakCount / Global.GuardBreakValue;
		if (guardBreak.value > 0.75f) {
			guardBreak.SetColor (Color.magenta);
		} else {
			guardBreak.RestoreColor ();
		}
		if (player.gauge >= gaugeFactor) {
			gauge.value = 1f;
		} else {
			gauge.value =  (float)(player.gauge/ Global.GuageValue);
		}

		if (player.enemy.GetComponent<Damage>().hitCount < 2) {
			hitCount.text = "";
		} else {
			hitCount.text = player.enemy.GetComponent<Damage>().hitCount.ToString();
		}
	}
}
