using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour {

	public bool battleStart;
	public GameObject player1;
	public GameObject player2;
	public Player character1;
	public Player character2;
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
		GameObject playerCharacter1 = Instantiate (player1, startPoint1.position, Quaternion.identity) as GameObject;
		GameObject playerCharacter2 = Instantiate (player2, startPoint2.position, Quaternion.identity) as GameObject;
		character1 = playerCharacter1.GetComponent<Player> ();
		character2 = playerCharacter2.GetComponent<Player> ();
		character1.controller = controler1;
		character2.controller = controler2;
		character1.controller.enable = false;
		character2.controller.enable = false;
		controler1.player = character1;
		controler2.player = character2;
		character1.id = 1;
		character2.id = 2;
		character1.enemy = playerCharacter2;
		character2.enemy = playerCharacter1;
		playergui1.player = character1;
		playergui2.player = character2;
		Invoke ("StartRound", 3);
		battleStart = true;
	}

	void Update(){
		if (character1.life <= 0 && battleStart) {
			Debug.Log ("Player 2 Ganhou");
			character1.controller.enable = false;
			character2.controller.enable = false;
			interfaceAnimator.Play ("Player1Win");
			character1.anim.SetBool ("OnDead", true);
			battleStart = false;
			Invoke ("ReloadScene", 3);
		}
		if(character2.life <= 0 && battleStart) {
			Debug.Log ("Player 1 Ganhou");
			character1.controller.enable = false;
			character2.controller.enable = false;
			interfaceAnimator.Play ("Player2Win");
			character2.anim.SetBool ("OnDead", true);
			battleStart = false;
			Invoke ("ReloadScene", 5);
		}
	}
	void StartRound(){
		battleStart = true;
		character1.controller.enable = true;
		character2.controller.enable = true;
	}
	void ReloadScene(){
		SceneManager.LoadScene("Main");
	}
}
