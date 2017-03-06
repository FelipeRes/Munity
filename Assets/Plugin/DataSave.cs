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
	string[] querys;

	void Start(){
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		dbcmd = dbconn.CreateCommand ();
	}

	void Update () {
		if (dataPull.round.battleStart) {
			query += dataPull.GetData ();
			dataCollectStart = true;
			count = 0;
		}
		if (dataCollectStart == true && dataPull.round.battleStart == false) {
			Debug.Log ("Inicia salvamento de dados");
			count++;
			string[] querys = query.Split ('\n');
			Debug.Log (querys.Length);
			if (count < querys.Length) {
				Debug.Log ("Save " + count);
				dbcmd.CommandText = querys[count];
				IDataReader reader = dbcmd.ExecuteReader ();
				reader.Close ();
				reader = null;
			}
			if (count >= query.Length) {
				dataCollectStart = false;
				dbcmd.Dispose ();
				dbcmd = null;
				dbconn.Close ();
				dbconn = null;
				dataCollectStart = false;
				Debug.Log ("Data save complete");
			}
		}
	}
}
