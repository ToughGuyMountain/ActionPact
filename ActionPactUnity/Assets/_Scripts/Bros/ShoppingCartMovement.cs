using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingCartMovement : MonoBehaviour {
	public float lateralSpeed;
	public float verticalSpeed;

	private Bro[] bros;
	private Animator animator;

	void Start() {
		bros = GetComponentsInChildren<Bro>();
		animator = GetComponent<Animator>();
	}

	void LateUpdate() {
		// movement of the cart depends on bro state 
		var displacement = CalculateMovement();
		transform.position += displacement;
		FaceDirection (displacement);
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