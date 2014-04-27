using UnityEngine;
using System.Collections;

public class DisableWhenNotInPlay : MonoBehaviour {
	public MonoBehaviour target;

	void OnEnable() {
		StartCoroutine(Util.AfterOneFrame(() => {
			MountainGame.Instance.play.Enter += OnEnter;
			MountainGame.Instance.play.Exit += OnExit;
		}));
	}

	void OnDisable() {
		MountainGame.Instance.play.Enter -= OnEnter;
		MountainGame.Instance.play.Exit -= OnExit;
	}

	void OnEnter() {
		target.enabled = true;
	}

	void OnExit() {
		target.enabled = false;
	}
}