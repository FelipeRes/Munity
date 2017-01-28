using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Singleton<MainController> {

	public List<PlayerInfo> playerInfos;

	void Awake(){
		playerInfos = new List<PlayerInfo> ();
	}
	public PlayerInfo StartNewPlayer(){
		PlayerInfo player = new PlayerInfo ();
		playerInfos.Add (player);
		player.Id = playerInfos.IndexOf (player);
		Debug.Log (playerInfos.Count);
		return player;
	}
}
