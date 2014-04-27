using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShoppingCartBros : MonoBehaviour {
	public float relativeLateralSpeed;
	public float relativeUpMountainSpeed;
	public float relativeDownMountainSpeed;
	public Animator rockyRoad;
	public Animator cart;
	public float rotationAngle = -30;
	public int brewCount;

	public StateMachineState stopped;
	public StateMachineState riding;
	public StateMachineState falling;
	public StateMachineState dead;

	private Vector3 startPosition;
	private Bro[] bros;
	private Animator animator;
	private RelativePan pan;
	
	void Start() {
		bros = GetComponentsInChildren<Bro>();
		animator = GetComponent<Animator>();
		pan = GetComponent<RelativePan> ();
		startPosition = transform.position;
		Restart();
		Game.Instance.Restart += Restart;
	}

	void LateUpdate() {
		// movement of the cart depends on bro state 
		var displacement = CalculateMovement();

		if (CanMakeMove (displacement)) {
			transform.position += displacement;
		}
	}

	void Restart() {
		brewCount = 0;
		animator.Play("Idle");
	}

	public void FellOffMountain() {
		StartCoroutine(RespawnAfterTime(2.0f));
	}

	public void RespawnZoneReached() {
		StartCoroutine(RespawnAfterTime(0.0f));
	}

	IEnumerator RespawnAfterTime(float time) {
		dead.SwitchTo();
		animator.Play("Idle");
		pan.enabled = false;
		rockyRoad.enabled = true;
		cart.enabled = true;
		transform.position = startPosition + new Vector3(1, .525f, 0) * 2.5f;
		yield return new WaitForSeconds (time);
		float t = 0;
		var startPos = transform.position;
		while (t < 1) {
			transform.position = Vector3.Lerp(startPos, startPosition, t);
			t += Time.deltaTime;
			yield return null;
		}

		Respawn ();
	}
	
	void Respawn() {
		riding.SwitchTo();
	}

	public void Fall() {
		falling.SwitchTo();
		animator.Play ("Fall");
	}

	public void HitObstacle(Hole hole) {
		animator.Play ("Wipeout");
		//StartCoroutine(Obstacle (hole));
	}

	public void Stopped() {
		// wiped out, so translate off the back of the screen
		pan.enabled = true;
		rockyRoad.enabled = false;
		cart.enabled = false;
		stopped.SwitchTo();

	}

	public void RestartLevel() {
		Game.Instance.Restart.Call();
	}

	IEnumerator Obstacle(Hole hole) {
		yield break;	
	}

	public void HitPowerup(MountainBrew brew) {
		// collect em
		brewCount++;
	}

	bool CanMakeMove(Vector3 displacement) {
		// do some mad hax to make the bros not go off the bottom of the screen at all
		if (!riding.Active) return false;
	
		var collider = GetComponentInChildren<Collider> ();
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

		return rotation * (MountainCam.Instance.speed * Time.deltaTime * (Vector3.right * -rightMost * relativeLateralSpeed + Vector3.up * -forwardMost * (forwardMost > 0 ? relativeDownMountainSpeed : relativeUpMountainSpeed)));
	}
}