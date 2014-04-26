using UnityEngine;
using System.Collections;

public class RestoreStartPositionOnRestart : MonoBehaviour {
	Vector3 startPos;

	void Start () {
		startPos = transform.position;
		Game.Instance.Restart += () => transform.position = startPos;
	}
}
