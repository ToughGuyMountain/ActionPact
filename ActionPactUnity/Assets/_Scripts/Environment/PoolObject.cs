using UnityEngine;
using System.Collections;
using System;

public class PoolObject : MonoBehaviour {
	public virtual void ReturnToPool() {}
	
	void Update() {
		var viewportPos = MountainGame.Instance.camera.WorldToViewportPoint(transform.position - collider.bounds.extents);
		if (viewportPos.x > 1 || viewportPos.y > 1) {
			ReturnToPool();
		}
	}
}