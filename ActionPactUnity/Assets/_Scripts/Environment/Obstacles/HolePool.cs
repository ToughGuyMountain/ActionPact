using UnityEngine;
using System.Collections;

public class HolePool : Pool<Hole> {
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}

	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			// hax: run the coroutine on the bros, cause they dont get disabled lol 
			//shoppingCartBros.
			//ReturnToPool();
			
		}
	}
}