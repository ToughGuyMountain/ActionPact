using UnityEngine;
using System.Collections;

public class MountainBrew : Powerup {
	public float speedBoost = 1;
	public float timeInEffect = 1;
	// future:
	//public AnimationCurve rampUpAndDown;
	//public float peakTime;

	public override void ReturnToPool() {
		MountainBrewPool.Instance.Push(this);
	}

	void OnTriggerEnter(Collider other) {
		var shoppingCartBros = other.GetComponent<ShoppingCartBros> ();
		if (shoppingCartBros) {
			// hax: run the coroutine on the bros, cause they dont get disabled lol 
			shoppingCartBros.HitPowerup(this);
			ReturnToPool();
		}
	}

}