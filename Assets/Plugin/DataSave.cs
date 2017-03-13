using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataSave : MonoBehaviour {

	public DataPull dataPull;
	//public string conn;
	//IDbConnection dbconn;
	//IDbCommand dbcmd;
	//string query;
	//public bool dataCollectStart;
	//public int count;
	//public int count2;
	//string[] querys;
	//public bool collectStart;

	void Start(){
		//count2 = 10;
		//conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		//dbconn = (IDbConnection)new SqliteConnection (conn);
		//dbconn.Open ();
		//dbcmd = dbconn.CreateCommand ();
	}

	void Update () {
		if (dataPull.round.battleStart) {
			//query += dataPull.GetData ();
			DataCache.Instance.query += dataPull.GetData ();
			//dataCollectStart = true;
		}
		if (Input.GetKey (KeyCode.Return)) {
			Save ();
		}
		/*if (dataCollectStart == true && dataPull.round.battleStart == false) {
			Debug.Log ("Data collect start");

			dbcmd.CommandText = query;
			IDataReader reader = dbcmd.ExecuteReader ();
			reader.Close ();
			reader = null;

			dbcmd.Dispose ();
			dbcmd = null;
			dbconn.Close ();
			dbconn = null;
			dataCollectStart = false;
			Debug.Log ("Data save complete");
		}*/
	}
	public void Save(){
		DataCache.Instance.Save ();
	}
}
