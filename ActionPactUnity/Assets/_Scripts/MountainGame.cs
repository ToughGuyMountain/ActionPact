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
	
	public Action Restart;
	public Action ReachedEnd;

	public StateMachineState play;
	public StateMachineState end;

	void Start() {
		OnRestart();
		Restart += OnRestart;
	}

	void OnRestart() {
		play.SwitchTo ();
		distanceTravelled = 0;
	}

	void Update() {
		distanceTravelled += speed * Time.deltaTime;
		if (AmountComplete >= 1 && play.Active) {
			end.SwitchTo();
			ReachedEnd.Call (); // redundant, i know (could have used event for comign into end state)
		}
	}
}
