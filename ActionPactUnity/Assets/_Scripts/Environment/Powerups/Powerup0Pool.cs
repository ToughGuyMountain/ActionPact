using UnityEngine;
using System.Collections;

public class Powerup0Pool : Pool<Powerup0> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}
}