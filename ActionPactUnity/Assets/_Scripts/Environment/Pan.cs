using UnityEngine;
using System.Collections;

public class Pan : MonoBehaviour {
	public float speed;
	public Vector3 direction;

	void Update() {
		transform.position += speed * direction * Time.deltaTime;
	}
}
