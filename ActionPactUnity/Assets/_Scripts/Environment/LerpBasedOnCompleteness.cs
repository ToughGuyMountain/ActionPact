using UnityEngine;
using System.Collections;

public class LerpBasedOnCompleteness : MonoBehaviour {
	Vector3 from;
	public Transform to;

	void Start() {
		from = transform.position;
	}

	void Update() {
		transform.position = Vector3.Lerp (from, to.position, MountainGame.Instance.AmountComplete);
	}
}