using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class IAControl : Controller {

	public string conn;
	IDbConnection dbconn;
	IDbCommand dbcmd;
	string query;
	public Player player;
	public string comands;
	public bool start;
	Data data;

	public void Config(){
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		dbcmd = dbconn.CreateCommand ();
		start = true;
	}
	void Update(){
		if (enable && start) {
			ReadData ();
			start = false;
		}
		if (!start) {
			checkCommands ();
		}
	}

	public virtual bool GetButton(Button button){
		if (enable) {
			switch (button) {
			case Button.UP:
				return Input.GetKey (Up);
			case Button.BACK:
				return Input.GetKey (Left);
			case Button.FORWARD:
				return Input.GetKey (Right);
			case Button.DOWN: 
				return Input.GetKey (Down);
			case Button.A: 
				return Input.GetKey (A);
			case Button.B: 
				return Input.GetKey (B);
			case Button.C: 
				return Input.GetKey (C);
			case Button.X: 
				return Input.GetKey (X);
			case Button.Y: 
				return Input.GetKey (Y);
			case Button.Z: 
				return Input.GetKey (Z);
			default:
				return false;
			}
		}
		return false;
	}
	public virtual bool GetButtonDown(Button button){
		if (enable) {
			switch (button) {
			case Button.UP:
				return Input.GetKeyDown (Up);
			case Button.BACK:
				return Input.GetKeyDown (Left);
			case Button.FORWARD:
				return Input.GetKeyDown (Right);
			case Button.DOWN: 
				return Input.GetKeyDown (Down);
			case Button.A: 
				return Input.GetKeyDown (A);
			case Button.B: 
				return Input.GetKeyDown (B);
			case Button.C: 
				return Input.GetKeyDown (C);
			case Button.X: 
				return Input.GetKeyDown (X);
			case Button.Y: 
				return Input.GetKeyDown (Y);
			case Button.Z: 
				return Input.GetKeyDown (Z);
			default:
				return false;
			}
		}
		return false;
	}
	void checkCommands(){
		float value_x = (player.transform.position.x - player.enemy.transform.position.x) / 2;
		//float value_y = (player.transform.position.y - player.enemy.transform.position.y) / 2;
		int index = 0;
		index = data.distancia_x.IndexOf (-1.874837f);
		Debug.Log (index);
		comands = data.botoes [index];

	}
	void ReadData(){
		data = new Data ();
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		query = "Select * from info";
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader ();
		Debug.Log ("Ler " + query);
		while (reader.Read ()) {
			data.distancia_x.Add (reader.GetFloat (0));
			data.distancia_y.Add (reader.GetFloat (1));
			data.life.Add (reader.GetFloat (2));
			data.meuEstado.Add (reader.GetString (3));
			data.estadoInimigo.Add (reader.GetString (4));
			data.botoes.Add (reader.GetString (5));
		}
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		dbconn = null;
		Debug.Log ("Database carregada com sucesso");
	}
}
