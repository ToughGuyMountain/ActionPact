using UnityEngine;
using System.Collections;

public class RespawnZone : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		var shoppingCart = other.transform.parent.GetComponent<ShoppingCartBros> ();
		if (shoppingCart) {
			shoppingCart.RespawnZoneReached();
		}
	}
}
