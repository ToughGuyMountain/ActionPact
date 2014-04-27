using UnityEngine;
using System.Collections;

public class ComicCamera : MonoBehaviour {
	public void Panel1() {
		MasterAudio.PlaySound ("comix");
	}

	public void ComicComplete() {
		SceneManager.Instance.gameScene.SwitchTo();
	}
}