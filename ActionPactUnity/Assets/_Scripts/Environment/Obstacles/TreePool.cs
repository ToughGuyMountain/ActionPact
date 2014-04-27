using UnityEngine;
using System.Collections;

public class TreePool : Pool<Tree> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}	
}