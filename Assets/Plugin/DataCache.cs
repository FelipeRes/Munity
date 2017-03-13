using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataCache : Singleton<DataCache> {

	public string query;
	public string conn;
	IDbConnection dbconn;
	IDbCommand dbcmd;
	string[] querys;

	public void Save(){
		conn = "URI=file:" + Application.dataPath + "/Plugin/aidata.s3db";
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open ();
		dbcmd = dbconn.CreateCommand ();

		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader ();
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		dbconn = null;
		Debug.Log ("Data save complete");

	}
}
