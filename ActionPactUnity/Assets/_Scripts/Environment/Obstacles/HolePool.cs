using UnityEngine;
using System.Collections;

public class HolePool : Pool<Hole> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}	
}