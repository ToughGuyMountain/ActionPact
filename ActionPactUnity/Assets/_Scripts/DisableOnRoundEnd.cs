using UnityEngine;
using System.Collections;

public class DisableOnRoundEnd : MonoBehaviour {
	public MonoBehaviour target;

	void OnEnable() {
		StartCoroutine(Util.AfterOneFrame(() => {
			MountainGame.Instance.ReachedEnd += OnReachedEnd;
			MountainGame.Instance.Restart += OnRestart;
		}));
	}
	
	void OnDisable(){
		MountainGame.Instance.ReachedEnd -= OnReachedEnd;
		MountainGame.Instance.Restart -= OnRestart;
	}
	
	void OnRestart() {
		target.enabled = true;
	}
	
	void OnReachedEnd() {
		target.enabled = false;
	}
}
