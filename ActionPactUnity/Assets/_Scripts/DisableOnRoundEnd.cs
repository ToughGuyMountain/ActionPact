using UnityEngine;
using System.Collections;

public class DisableOnRoundEnd : MonoBehaviour {
	public MonoBehaviour target;

	void Start() {
		MountainGame.Instance.end.Enter += OnReachedEnd;
		MountainGame.Instance.end.Exit += OnRestart;
	}
	
	void OnRestart() {
		target.enabled = true;
	}
	
	void OnReachedEnd() {
		target.enabled = false;
	}
}
