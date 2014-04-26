using UnityEngine;
using System.Collections;

public class MountainBrewPool : Pool<MountainBrew> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}	
}