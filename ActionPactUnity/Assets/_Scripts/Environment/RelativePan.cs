using UnityEngine;
using System.Collections;

// relative to the game's current speed
public class RelativePan : MonoBehaviour {
	public float ratio;
	public Vector3 direction;
	
	void Update() {
		transform.position += ratio * ShoppingCartBros.Instance.Speed * direction.normalized * Time.deltaTime;
	}
}
