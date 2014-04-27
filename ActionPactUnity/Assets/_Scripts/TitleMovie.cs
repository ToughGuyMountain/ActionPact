using UnityEngine;
using System.Collections;

public class TitleMovie : MonoBehaviour {
	
	void Start () {
		(renderer.material.mainTexture as MovieTexture).Play();
	}

	public void MovieFinished() {
		SceneManager.Instance.comicScene.SwitchTo ();
	}
}