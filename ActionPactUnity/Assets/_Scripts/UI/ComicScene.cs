using UnityEngine;
using System.Collections;

public class ComicScene : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.Instance.gameScene.SwitchTo();
		}
	}
}