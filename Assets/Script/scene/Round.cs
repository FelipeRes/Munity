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
	public Transform startPoint1;
	public Transform startPoint2;
	public Animator interfaceAnimator;
	public PlayerGUI playergui1;
	public PlayerGUI playergui2;
	public float time;
	public Text playerGuiTime;
	// Use this for initialization
	void Start () {
		Debug.Log ("Inicializando Configuracao");
		playerObject1 = MainController.Instance.playerInfos [0].character.gameObject;
		playerObject2 = MainController.Instance.playerInfos [1].character.gameObject;
		GameObject playerCharacter1 = Instantiate (playerObject1, startPoint1.position, Quaternion.identity) as GameObject;
		GameObject playerCharacter2 = Instantiate (playerObject2, startPoint2.position, Quaternion.identity) as GameObject;
		player1 = playerCharacter1.GetComponent<Player> ();
		player2 = playerCharacter2.GetComponent<Player> ();
		//player1.controller = MainController.Instance.playerInfos [0].contoller;
		player2.controller = MainController.Instance.playerInfos [1].contoller;

		GameObject con = Instantiate (MainController.Instance.playerInfos [0].contoller.gameObject) as GameObject;
		player1.controller = con.GetComponent<IAControl>();
		con.GetComponent<IAControl>().player = player1;
		con.GetComponent<IAControl>().Config ();



		player1.controller.enable = false;
		player2.controller.enable = false;
		player1.id = MainController.Instance.playerInfos [0].Id;
		player2.id = MainController.Instance.playerInfos [1].Id;;
		player1.enemy = playerCharacter2;
		player2.enemy = playerCharacter1;
		playergui1.player = player1;
		playergui2.player = player2;
		Invoke ("StartRound", 3);
		Debug.Log ("Finalizando Configuracao");
	}

	void Update(){
		if (battleStart) {
			time -= Time.deltaTime;
			playerGuiTime.text = ((int)(time)).ToString ();
			if(time <= 0){
				battleStart = false;
				if (player1.life > player2.life) {
					interfaceAnimator.Play ("Player1Win");
					EndBattle (player2, player1);
				} else if (player2.life > player1.life) {
					interfaceAnimator.Play ("Player2Win");
					EndBattle (player1, player2);
				} else if(player1.life == player2.life){
					interfaceAnimator.Play ("DrawnGame");
					DrawGame ();
				}
			}
		}
		if (player1.life <= 0 && battleStart) {
			interfaceAnimator.Play ("Player1Win");
			EndBattle (player2,player1);
		}
		if(player2.life <= 0 && battleStart) {
			interfaceAnimator.Play ("Player2Win");
			EndBattle (player1,player2);
		}
	}
	void StartRound(){
		player1.controller.enable = true;
		player2.controller.enable = true;
		battleStart = true;
	}
	void EndBattle(Player win, Player lose){
		win.controller.enable = false;
		lose.controller.enable = false;
		lose.anim.SetBool ("OnDead", true);
		battleStart = false;
		Invoke ("ReloadScene", 5);
	}
	void DrawGame(){
		player1.controller.enable = false;
		player2.controller.enable = false;
		Invoke ("ReloadScene", 5);
	}
	void ReloadScene(){
		SceneManager.LoadScene("Main");
	}
}
