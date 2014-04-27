using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {
	
	void Start () {
		(renderer.material.mainTexture as MovieTexture).Play();
	}

}
