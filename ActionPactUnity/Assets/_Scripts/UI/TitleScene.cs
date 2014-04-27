using UnityEngine;
using System.Collections;

public class TitleScene : Singleton<TitleScene> {
	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.Instance.comicScene.SwitchTo ();
		}
	}

	public void FistBump() {
		MasterAudio.PlaySound ("chyea");
	}

	public void ACTIONPACT() {
		MasterAudio.PlaySound ("ACTIONPACT");
	}

	public void MovieFinished() {
		SceneManager.Instance.comicScene.SwitchTo ();
	}
}