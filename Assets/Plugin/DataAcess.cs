using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataAcess : MonoBehaviour {

	public string conn;

	void Start () {
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		IDbConnection dbconn;
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "select distancia_x from info";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader ();
		Debug.Log ("Ler");
		while (reader.Read ()) {
			float value = reader.GetFloat (0);
			Debug.Log (value);
		}
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		dbconn = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
