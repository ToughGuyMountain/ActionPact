using UnityEngine;
using System.Collections;

public class RestoreStartPositionOnRestart : MonoBehaviour {
	Vector3 startPos;

	void Start () {
		startPos = transform.position;

	}

	void OnEnable() {
		StartCoroutine(Util.AfterOneFrame(() => {
			MountainGame.Instance.end.Exit += OnRestart;
		}));
	}

	void OnRestart() {
		transform.position = startPos;
	}

	void OnDisable(){
		MountainGame.Instance.end.Exit -= OnRestart;
	}
}
