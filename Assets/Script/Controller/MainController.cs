using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Singleton<MainController> {

	public List<PlayerInfo> playerInfos;

	void Awake(){
		playerInfos = new List<PlayerInfo> ();
	}
	public void StartNewPlayer(Character character, Controller controller, PlayerInfo playerInfoBase){
		PlayerInfo player = Instantiate (playerInfoBase, this.transform);
		player.character = character;
		player.contoller = controller;
		Debug.Log (controller.gameObject.name);
		player.Id = playerInfos.Count+1;
		playerInfos.Add(player);
	}
}
