using UnityEngine;
using System.Collections;

public class DisableOnRoundEnd : MonoBehaviour {
	public MonoBehaviour target;

	void OnEnable() {
		StartCoroutine(Util.AfterOneFrame(() => {
			MountainGame.Instance.end.Enter += OnReachedEnd;
			MountainGame.Instance.end.Exit += OnRestart;
		}));
	}
	
	void OnDisable(){
		MountainGame.Instance.end.Enter -= OnReachedEnd;
		MountainGame.Instance.end.Exit -= OnRestart;
	}
	
	void OnRestart() {
		target.enabled = true;
	}
	
	void OnReachedEnd() {
		target.enabled = false;
	}
}
