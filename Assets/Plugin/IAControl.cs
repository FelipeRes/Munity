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
	public bool start;
	Data data;
	public List<int> idexList_dist_x = new List<int> ();
	public List<int> idexList_dist_y = new List<int> ();
	public List<int> countIndex = new List<int>();
	public int index;
	public List<int> indexList = new List<int>();

	public void Config(){
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		dbcmd = dbconn.CreateCommand ();
		start = true;
		enable = false;
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

	public override bool GetButton(Button button){
		if (enable && player != null && !start) {
			switch (button) {
			case Button.UP:
				return data.button_up[index];
			case Button.BACK:
				return data.button_right[index];
			case Button.FORWARD:
				return data.button_left[index];
			case Button.DOWN: 
				return data.button_down[index];
			case Button.A: 
				return data.button_b[index];
			case Button.B: 
				return data.button_c[index];
			case Button.C: 
				return data.button_c[index];
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
		if (button == Button.A) {
			return Input.GetKeyDown (A);
		}
		return false;
	}
	public override bool GetButtonDown(Button button){
		if (enable && player != null && !start) {
			switch (button) {
			case Button.UP:
				return data.button_up[index];
			case Button.BACK:
				return data.button_right[index];
			case Button.FORWARD:
				return data.button_left[index];
			case Button.DOWN: 
				return data.button_down[index];
			case Button.A: 
				return data.button_a[index];
			case Button.B: 
				return data.button_b[index];
			case Button.C: 
				return data.button_c[index];
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
		if (button == Button.A) {
			return Input.GetKeyDown (A);
		}
		return false;
	}
	void checkCommands(){
		int value_x = (int)((player.transform.position.x - player.enemy.transform.position.x) / 2);
		int value_y = (int)((player.transform.position.y - player.enemy.transform.position.y) / 2);
		idexList_dist_x.Clear();
		countIndex.Clear ();
		for (int i = 0; i < data.distancia_x.Count; i++) {
			if (value_x == data.distancia_x [i]) {
				idexList_dist_x.Add (i);
			}
		}
		idexList_dist_y.Clear();
		for (int i = 0; i < data.distancia_y.Count; i++) {
			if (value_y == data.distancia_y [i]) {
				idexList_dist_y.Add (i);
			}
		}
		for(int i = 0; i < idexList_dist_x.Count; i++){
			for (int j = 0; j < idexList_dist_y.Count; j++) {
				if (idexList_dist_x [i] == idexList_dist_y [j]) {
					index = idexList_dist_x [i];
					int qntIndex = data.count [index];
					for(int x = 0; x< qntIndex; x++){
						countIndex.Add (index);
					}
				}
			}
		}
		if (countIndex.Count > 0) {
			int rand = Random.Range (0, countIndex.Count);
			index = countIndex [rand];
		}


	}
	void ReadData(){
		data = new Data ();
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		//query = "Select *, count(*) from info group by distancia_x, distancia_y";
		query = "select *,count(*) from player group by distancia_x, distancia_y, button_up, button_down, button_left, button_right, button_a, button_b, button_c";
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader ();
		Debug.Log ("Ler " + query);
		while (reader.Read ()) {
			data.distancia_x.Add (reader.GetFloat (0));
			data.distancia_y.Add (reader.GetFloat (1));
			data.button_up.Add (reader.GetBoolean (2));
			data.button_down.Add (reader.GetBoolean (3));
			data.button_left.Add (reader.GetBoolean (4));
			data.button_right.Add (reader.GetBoolean (5));
			data.button_a.Add (reader.GetBoolean (6));
			data.button_b.Add (reader.GetBoolean (7));
			data.button_c.Add (reader.GetBoolean (8));
			data.count.Add (reader.GetInt32 (9));
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
