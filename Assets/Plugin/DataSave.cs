using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class DataSave : MonoBehaviour {

	public DataPull dataPull;

	void Start(){;
	}

	void Update () {
		if (dataPull.round.battleStart) {
			dataPull.GetData ();
		}

	}
}
