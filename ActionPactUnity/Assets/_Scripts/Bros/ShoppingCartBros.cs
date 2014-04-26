﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingCartBros : Singleton<ShoppingCartBros> {
	public float lateralSpeed;
	public float verticalSpeed;
	public float startSpeed = 1;
	public float Speed { get; set; }	
	public float distanceTravelled;
	public float mountainHeight; 
	public float PercentComplete { 
		get { return distanceTravelled / mountainHeight; }
	}	

	private Bro[] bros;
	private Animator animator;


	
	void Start() {
		Speed = startSpeed;
		bros = GetComponentsInChildren<Bro>();
		animator = GetComponent<Animator>();
	}

	void LateUpdate() {
		// movement of the cart depends on bro state 
		var displacement = CalculateMovement();

		FaceDirection (displacement);

		var futureViewportSpacePosition = Camera.main.WorldToViewportPoint(transform.position + displacement + collider.bounds.extents);
		if (futureViewportSpacePosition.x >= 1 || 
		    futureViewportSpacePosition.y >= 1 || 
		    futureViewportSpacePosition.y <= 0) {
			displacement = Vector3.zero;
		}

		transform.position += displacement;
	}

	public void Fall() {
		animator.Play ("Fall");
	}

	Vector3 CalculateMovement() {
		int leftCount = 0;
		int rightCount = 0;
		int backCount = 0;
		int forwardCount = 0;
		Array.ForEach(bros, bro => { 
			if (bro.leaningLeft.Active) leftCount++;
			if (bro.leaningRight.Active) rightCount++;
			if (bro.leaningForward.Active) forwardCount++;
			if (bro.leaningBack.Active) backCount++;
		});

		float rightMost = ((float)rightCount - leftCount) / bros.Length;
		float forwardMost = ((float)forwardCount - backCount) / bros.Length; 
		return (-rightMost * Vector3.right * lateralSpeed * Time.deltaTime);

		//return ((-rightMost * Vector3.right) - (forwardMost * new Vector3(1,1,0))).normalized * lateralSpeed * Time.deltaTime;
	}

	void FaceDirection(Vector3 displacement) {
		if (displacement.x > 0) {
			//animator.Play ("TurnLeft");
		}
	}
}