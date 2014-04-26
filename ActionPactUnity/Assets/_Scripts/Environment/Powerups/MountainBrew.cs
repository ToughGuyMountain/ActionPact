using UnityEngine;
using System.Collections;

public class MountainBrew : Powerup {
	public override void ReturnToPool() {
		MountainBrewPool.Instance.Push(this);
	}

	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			shoppingCartBros.Powerup(this);
			ReturnToPool();
		}
	}
}