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
		gauge.value = (player.gauge >= gaugeFactor) ? 1f : (float)(player.gauge / gaugeFactor);
		hitCount.text = (player.enemy.GetComponent<SimpleDamage> ().HitCount < 2) ? "" : player.enemy.GetComponent<SimpleDamage> ().HitCount.ToString ();
	}
}
