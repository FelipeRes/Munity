using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Round : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public Player character1;
	public Player character2;
	public Bar lifeBar1;
	public Bar lifeBar2;
	public Bar gauge1;
	public Bar gauge2;
	public Text hitCount1;
	public Text hitCount2;
	public Transform startPoint1;
	public Transform startPoint2;
	// Use this for initialization
	void Start () {
		GameObject playerCharacter1 = Instantiate (player1, startPoint1.position, Quaternion.identity) as GameObject;
		GameObject playerCharacter2 = Instantiate (player2, startPoint2.position, Quaternion.identity) as GameObject;
		character1 = playerCharacter1.GetComponent<Player> ();
		character2 = playerCharacter2.GetComponent<Player> ();
		character1.id = 1;
		character2.id = 2;
		character1.enemy = playerCharacter2;
		character2.enemy = playerCharacter1;
		playerCharacter1.GetComponent<InterfacePlayer> ().lifebar = lifeBar1;
		playerCharacter2.GetComponent<InterfacePlayer> ().lifebar = lifeBar2;
		playerCharacter1.GetComponent<InterfacePlayer> ().gauge = gauge1;
		playerCharacter2.GetComponent<InterfacePlayer> ().gauge = gauge2;
		playerCharacter1.GetComponent<InterfacePlayer> ().hitCount = hitCount1;
		playerCharacter2.GetComponent<InterfacePlayer> ().hitCount = hitCount2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
