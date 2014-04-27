using UnityEngine;
using System.Collections;

public class SceneManager : Singleton<SceneManager> {
	public StateMachineState comicScene;
	public StateMachineState gameScene;
	public StateMachineState titleScene;
	public StateMachineState slapFiveScene;

	void Start() {
		StartCoroutine(Util.AfterOneFrame(()=>titleScene.SwitchTo()));
	}
}