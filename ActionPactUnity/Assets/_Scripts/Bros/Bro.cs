using UnityEngine;
using System.Collections;

public class Bro : MonoBehaviour {
	public KeyCode left;
	public KeyCode right;
	public KeyCode up;
	public KeyCode down;

	public StateMachineState idle;
	public StateMachineState leaningLeft;
	public StateMachineState leaningRight;
	
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
			idle.SwitchTo();
		}
	}
}
