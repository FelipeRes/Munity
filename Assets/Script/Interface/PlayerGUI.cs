using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGUI : MonoBehaviour {

	public Player player;
	public Bar lifeBar;
	public Bar gauge;
	public float lifeFactor;
	public float gaugeFactor;
	public Text hitCount;

	void Update () {
		lifeBar.value = player.life / lifeFactor;
		if (player.gauge >= gaugeFactor) {
			gauge.value = 1f;
		} else {
			gauge.value =  (float)(player.gauge/ gaugeFactor);
		}
		if (player.enemy.GetComponent<SimpleDamage>().HitCount < 2) {
			hitCount.text = "";
		} else {
			hitCount.text = player.enemy.GetComponent<SimpleDamage>().HitCount.ToString();
		}
	}
}
