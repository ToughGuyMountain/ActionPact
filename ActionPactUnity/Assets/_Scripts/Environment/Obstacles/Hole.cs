using UnityEngine;
using System.Collections;

public class Hole : Obstacle {
	public override void ReturnToPool() {
		HolePool.Instance.Push(this);
	}

	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			shoppingCartBros.HitObstacle(this);
		}
	}
}