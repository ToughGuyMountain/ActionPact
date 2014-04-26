using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Game : Singleton<Game> {
	public float speed = 1;	
	public float distanceTravelled;
	public float mountainHeight; 
	public float PercentComplete { 
		get { return distanceTravelled / mountainHeight; }
	}
}