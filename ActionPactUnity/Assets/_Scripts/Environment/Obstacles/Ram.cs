using UnityEngine;
using System.Collections;

public class Ram : Obstacle {

	public void Start() {
		float x = Random.Range(-3.0f, -1.0f);
		float y = Random.Range(0.75f, 2.0f);
		this.GetComponent<RelativePan>().direction = new Vector3(x, y, 0.0f); 
	}

	public override void ReturnToPool() {
		RamPool.Instance.Push(this);
	}

	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.transform.parent.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			shoppingCartBros.HitObstacle(this);
		}
	}
}
