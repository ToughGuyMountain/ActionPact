using UnityEngine;
using System.Collections;

public class Bro : MonoBehaviour {
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;

	public StateMachineState idleLateral;
	public StateMachineState idleVertical;
	public StateMachineState leaningLeft;
	public StateMachineState leaningRight;
	public StateMachineState leaningBack;
	public StateMachineState leaningForward;
	public StateMachineState recovering;

	void OnEnable(){ 
		StartCoroutine(Util.AfterOneFrame(()=> {
			recovering.Enter += () => StartCoroutine(RecoverForSeconds(1.0f));
		}));
	}

	void Update() { 
		HandleInput();
	}

	void HandleInput() {
		if (Input.GetKey (left)) {
			// the bro is leaning right, but that means the cart moves left on the screen, 
			// so the natural key mapping is the reverse
			leaningRight.SwitchTo();
		} 
		else if (Input.GetKey (right)) {
			leaningLeft.SwitchTo();
		}
		else {
			idleLateral.SwitchTo();
		}

		if (Input.GetKey (up)) {
			leaningBack.SwitchTo();
		}
		else if (Input.GetKey (down)) {
			leaningForward.SwitchTo();
		}
		else {
			idleVertical.SwitchTo();
		}
	}

	IEnumerator RecoverForSeconds(float secs) {
		for (float i = 0.0f; i < secs; i+=0.2f) {
			yield return new WaitForSeconds(0.1f);
			transform.parent.GetComponent<SpriteRenderer>().renderer.enabled = false;
			yield return new WaitForSeconds(0.1f);
			transform.parent.GetComponent<SpriteRenderer>().renderer.enabled = true;
		}
		this.transform.parent.GetComponent<SpriteRenderer>().renderer.enabled = true;
		recovering.SwitchFrom();
	}
}
