using UnityEngine;
using System.Collections;

public class Obstacle0Pool : Pool<Obstacle0> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}
}