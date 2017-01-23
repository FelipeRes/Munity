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
		player = this.GetComponent<Player> ();
	}

	void Update () {
		lifebar.value = player.life / lifeFactor;
		if (player.gauge >= gaugeFactor) {
 -			gauge.value = 1f;
 -		} else {
 -			gauge.value =  (float)(player.gauge/ gaugeFactor);
 -		}
 -		if (player.enemy.GetComponent<SimpleDamage>().HitCount < 2) {
 -			hitCount.text = "";
 -		} else {
 -			hitCount.text = player.enemy.GetComponent<SimpleDamage>().HitCount.ToString();
 -		}
	}
}
