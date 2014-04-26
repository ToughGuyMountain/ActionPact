using UnityEngine;
using System.Collections;

public class Obstacle0 : Obstacle {
	public override void ReturnToPool() {
		Obstacle0Pool.Instance.Push(this);
	}
}