using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour {

	public bool battleStart;
	public GameObject playerObject1;
	public GameObject playerObject2;
	public Player player1;
	public Player player2;
	public Controller controler1;
	public Controller controler2;
	public Transform startPoint1;
	public Transform startPoint2;
	public Animator interfaceAnimator;
	public PlayerGUI playergui1;
	public PlayerGUI playergui2;
	public 
	// Use this for initialization
	void Start () {
		GameObject playerCharacter1 = Instantiate (playerObject1, startPoint1.position, Quaternion.identity) as GameObject;
		GameObject playerCharacter2 = Instantiate (playerObject2, startPoint2.position, Quaternion.identity) as GameObject;
		player1 = playerCharacter1.GetComponent<Player> ();
		player2 = playerCharacter2.GetComponent<Player> ();
		player1.controller = controler1;
		player2.controller = controler2;
		player1.controller.enable = false;
		player2.controller.enable = false;
		controler1.player = player1;
		controler2.player = player2;
		player1.id = 1;
		player2.id = 2;
		player1.enemy = playerCharacter2;
		player2.enemy = playerCharacter1;
		playergui1.player = player1;
		playergui2.player = player2;
		Invoke ("StartRound", 3);
		battleStart = true;
	}

	void Update(){
		if (player1.life <= 0 && battleStart) {
			Debug.Log ("Player 2 Ganhou");
			player1.controller.enable = false;
			player2.controller.enable = false;
			interfaceAnimator.Play ("Player1Win");
			player1.anim.SetBool ("OnDead", true);
			battleStart = false;
			Invoke ("ReloadScene", 3);
		}
		if(player2.life <= 0 && battleStart) {
			Debug.Log ("Player 1 Ganhou");
			player1.controller.enable = false;
			player2.controller.enable = false;
			interfaceAnimator.Play ("Player2Win");
			player2.anim.SetBool ("OnDead", true);
			battleStart = false;
			Invoke ("ReloadScene", 5);
		}
	}
	void StartRound(){
		battleStart = true;
		player1.controller.enable = true;
		player2.controller.enable = true;
	}
	void ReloadScene(){
		SceneManager.LoadScene("Main");
	}
}
