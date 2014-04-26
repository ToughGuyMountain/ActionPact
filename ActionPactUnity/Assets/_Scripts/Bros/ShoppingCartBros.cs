using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingCartBros : Singleton<ShoppingCartBros> {
	public float relativeLateralSpeed;
	public float relativeUpMountainSpeed;
	public float relativeDownMountainSpeed;
	public float startSpeed = 1;
	public float Speed { get; set; }	
	public float distanceTravelled;
	public float mountainHeight; 
	public float PercentComplete { 
		get { return distanceTravelled / mountainHeight; }
	}	
	public float rotationAngle = -30;

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

		if (CanMakeMove (displacement)) {
			transform.position += displacement;
		}
	}

	public void Fall() {
		animator.Play ("Fall");
	}

	bool CanMakeMove(Vector3 displacement) {
		// do some mad hax to make the bros not go off the bottom of the screen at all
		var futureViewportSpacePosition = Camera.main.WorldToViewportPoint(transform.position + displacement + 
			((Camera.main.WorldToViewportPoint(transform.position).y < 0.5f) ? 
		 	new Vector3(collider.bounds.extents.x, -collider.bounds.extents.y, collider.bounds.extents.z) 
		 	: collider.bounds.extents)
		);

		if (futureViewportSpacePosition.x >= 1 || 
		    futureViewportSpacePosition.y >= 1 || 
		    futureViewportSpacePosition.y <= 0) {
			return false;
		}
		else {
			return true;
		}
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

		var rotation = Quaternion.Euler (new Vector3 (0, 0, rotationAngle));

		return rotation * (Speed * Time.deltaTime * (Vector3.right * -rightMost * relativeLateralSpeed + Vector3.up * -forwardMost * (forwardMost > 0 ? relativeDownMountainSpeed : relativeUpMountainSpeed)));
	}

	void FaceDirection(Vector3 displacement) {
		if (displacement.x > 0) {
			//animator.Play ("TurnLeft");
		}
	}
}