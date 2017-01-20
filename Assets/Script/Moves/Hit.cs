using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public int damage;
	public int gauge;
	public bool derrubar;
	public SkillHeight height;
	public float stunTime;
	public float stopTime;
	public Vector2 recuo;
	public Vector2 recuoNoAr;
	public GameObject hitEffect;
	public Player player;
}
