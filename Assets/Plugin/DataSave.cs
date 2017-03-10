using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataSave : MonoBehaviour {

	public DataPull dataPull;
	public string conn;
	IDbConnection dbconn;
	IDbCommand dbcmd;
	string query;
	public bool dataCollectStart;
	public int count;
	public int count2;
	string[] querys;
	public bool collectStart;
	void Start(){
		count2 = 10;
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		dbcmd = dbconn.CreateCommand ();
	}

	void Update () {
		if (dataPull.round.battleStart) {
			query += dataPull.GetData ();
			dataCollectStart = true;
		}
		if (dataCollectStart == true && dataPull.round.battleStart == false) {
			/*string[] querys = query.Split ('\n');
			for (int i = 0; i < querys.Length; i++) {
				Save(querys[i]);
			}*/
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
		}
	}
	void Save(string q){
		dbcmd.CommandText = q;
		IDataReader reader = dbcmd.ExecuteReader ();
		reader.Close ();
		reader = null;
	}
}
