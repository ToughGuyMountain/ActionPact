using UnityEngine;
using System;
using System.Collections;

public static class Util {
	public static IEnumerator AfterOneFrame(Action action) {
		yield return new WaitForEndOfFrame();
		action.Call ();
	}
}