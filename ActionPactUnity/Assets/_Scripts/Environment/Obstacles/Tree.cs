using UnityEngine;
using System.Collections;

public class Tree : Obstacle {
	public override void ReturnToPool() {
		TreePool.Instance.Push(this);
	}
	
	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.transform.parent.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			shoppingCartBros.HitObstacle(this);
		}
	}
}