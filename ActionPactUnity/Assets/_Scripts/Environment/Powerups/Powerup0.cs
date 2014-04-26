using UnityEngine;
using System.Collections;

public class Powerup0 : Powerup {
	public override void ReturnToPool() {
		Powerup0Pool.Instance.Push(this);
	}
}