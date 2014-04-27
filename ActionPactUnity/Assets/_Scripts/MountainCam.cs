using UnityEngine;
using System;
using System.Collections;

public class MountainCam : Singleton<MountainCam> {
	public float speed;
	public float distanceTravelled;
	public float mountainHeight; 
	public float AmountComplete { 
		get { return distanceTravelled / mountainHeight; }
	}	
	
	public Action ReachedEnd;

	void Start() {
		Restart();
		Game.Instance.Restart += Restart;
	}

	void Restart() {
		distanceTravelled = 0;
	}

	void Update() {
		distanceTravelled += speed * Time.deltaTime;
		if (AmountComplete >= 1) {
			ReachedEnd.Call();
		}
	}
}
