using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfacePlayer : MonoBehaviour {

	public Player player;
	public SimpleDamage simpleDamage;
	public Bar lifebar;
	public Bar gauge;
	public Text hitCount;
	public float lifeFactor;
	public float gaugeFactor;
	void Start () {
	}

	void Update () {
		lifebar.value = player.life / lifeFactor;
		if (gauge.value >= 1) {
			gauge.value = 1;
		} else {
			gauge.value =  player.gauge/ gaugeFactor;
		}
		if (player.enemy.GetComponent<SimpleDamage>().HitCount < 2) {
			hitCount.text = "";
		} else {
			hitCount.text = player.enemy.GetComponent<SimpleDamage>().HitCount.ToString();
		}
	}
}
