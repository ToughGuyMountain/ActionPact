using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingCartMovement : MonoBehaviour {
	Bro[] bros;
	public float lateralSpeed;

	void Start() {
		bros = GetComponentsInChildren<Bro> ();
	}

	void LateUpdate() {
		// movement of the cart depends on bro state 
		var displacement = CalculateMovement();
		transform.position += displacement;
	}

	Vector3 CalculateMovement() {
		int leftCount = 0;
		int rightCount = 0;
		Array.ForEach(bros, bro => { 
			if (bro.leaningLeft.Active) leftCount++;
			if (bro.leaningRight.Active) rightCount++;
		});

		int rightMost = rightCount - leftCount;
		return new Vector3(-rightMost * lateralSpeed * Time.deltaTime, 0, 0);
	}
}