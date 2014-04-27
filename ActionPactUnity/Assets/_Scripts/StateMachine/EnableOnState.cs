using UnityEngine;
using System.Collections;

public class EnableOnState : MonoBehaviour {
	StateMachineState state;
	[SerializeField] Behaviour behaviour;
	
	void Start() {
		state = GetComponent<StateMachineState>();
		state.Enter += Enter;
		state.Exit += Exit;
		// give 'em a chance to start up
		StartCoroutine(
			Util.AfterOneFrame(
			() => behaviour.enabled = false)
		)
		;
	}
	
	void Enter() {
		behaviour.enabled = true;
	}
	
	void Exit() {
		behaviour.enabled = false;
	}
}
