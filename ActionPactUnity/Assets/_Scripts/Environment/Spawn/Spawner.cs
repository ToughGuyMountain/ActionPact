using UnityEngine;
using System;
using System.Collections;

public class Spawner : MonoBehaviour {
	public Func<float> SpawnWeight;
	public Action Spawn;
}
