using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
	public float minSpawnTime;
	public float maxSpawnTime;	
	float lastSpawnTime;
	public float nextSpawnTime;
	Spawner[] spawners;

	void Start() {
		lastSpawnTime = Time.realtimeSinceStartup;
		nextSpawnTime = minSpawnTime + maxSpawnTime * UnityEngine.Random.value;
		spawners = GetComponentsInChildren<Spawner>();
	}

	void Spawn() {
		lastSpawnTime = Time.realtimeSinceStartup;
		nextSpawnTime = minSpawnTime + maxSpawnTime * UnityEngine.Random.value;

		// you have n weights, normalized over the range 0..1
		// you have a random value that acts as a chooser
		// sort the weights in ascending order
		// the weights can be seen as partioning a 1-D space (line)
		// if the value is less than the first weight, choose that
		// if the value is greater than or equal to the first weight, and less than the second weight + the first weight, choose the second 
	
		spawners[WhichToSpawn()].Spawn();
	}

	int WhichToSpawn() {
		int whichToSpawn = 0;
		var randomValue = UnityEngine.Random.value;
		float soFar = 0;
		Array.ForEach (spawners, spawner => {
			var normWeight = spawner.SpawnWeight() / spawners.Length;

			if (randomValue >= soFar && randomValue < normWeight) {
				return;
			}
			soFar += normWeight;
			whichToSpawn++;
		});
		return whichToSpawn;
	}


	void Update() {
		if (Time.realtimeSinceStartup - lastSpawnTime >= nextSpawnTime) {
			Spawn();
		}
	}
}