using UnityEngine;
using System.Collections;

public class FallBoundary : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		var shoppingCart = other.GetComponent<ShoppingCartBros> ();
		if (shoppingCart) {
			shoppingCart.Fall();
		}
	}
}