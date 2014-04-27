using UnityEngine;
using System;
using System.Collections;

public class MountainGame : Singleton<MountainGame> {
	public float speed;
	public float distanceTravelled;
	public float mountainHeight; 
	public float AmountComplete { 
		get { return distanceTravelled / mountainHeight; }
	}	

	public StateMachineState play;
	public StateMachineState end;

	public Camera camera;

	void Start() {
		end.Exit += OnRestart;
		//MasterAudio.StopPlaylist();
		Debug.Log ("yolo");
		StartCoroutine(
			Util.AfterOneFrame(() => {
				SceneManager.Instance.gameScene.Enter += () => {
				Debug.Log ("yes");
					MasterAudio.PlaySound("song");
					camera.enabled = true;
					play.SwitchTo();
				};
			}
		));

		StartCoroutine(
			Util.AfterOneFrame(() => {
			SceneManager.Instance.gameScene.Exit += () => {
				camera.enabled = false;
				end.SwitchTo();
			};
		}
		));

	}

	void OnRestart() {
		distanceTravelled = 0;
	}

	void Update() {
		if (play.Active) {
			distanceTravelled += speed * Time.deltaTime;
			if (AmountComplete >= 1 && play.Active) {
					end.SwitchTo ();
					StartCoroutine (EndSequence ());
			}
		}
	}

	IEnumerator EndSequence() {
		yield return new WaitForSeconds(3.0f);
		play.SwitchTo ();
	}
}
