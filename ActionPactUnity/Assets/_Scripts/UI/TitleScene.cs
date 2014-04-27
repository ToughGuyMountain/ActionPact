using UnityEngine;
using System.Collections;

public class TitleScene : Singleton<TitleScene> {
	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.Instance.comicScene.SwitchTo ();
		}
	}
}