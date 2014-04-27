using UnityEngine;
using System;
using System.Collections;

public class MountainGame : Singleton<MountainGame> {
	public float speed;
	public float distanceTravelled;
	public float mountainHeight; 
	public float AmountComplete { 
		get { return distanceTravelled / mountainHeight; }
	}	

	public StateMachineState play;
	public StateMachineState end;

	void Start() {
		end.Exit += OnRestart;
		StartCoroutine (Util.AfterOneFrame (() => play.SwitchTo ()));
	}

	void OnRestart() {
		distanceTravelled = 0;
	}

	void Update() {
		distanceTravelled += speed * Time.deltaTime;
		if (AmountComplete >= 1 && play.Active) {
			end.SwitchTo();
			StartCoroutine(EndSequence());
		}
	}

	IEnumerator EndSequence() {
		yield return new WaitForSeconds(3.0f);
		play.SwitchTo ();
	}
}
