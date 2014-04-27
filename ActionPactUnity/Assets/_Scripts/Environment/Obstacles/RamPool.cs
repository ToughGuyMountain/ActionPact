using UnityEngine;
using System.Collections;

public class RamPool : Pool<Ram> {
	
	void Start() {
		var spawner = GetComponent<Spawner> ();
		spawner.SpawnWeight = () => 1;
		spawner.Spawn = Spawn;
	}	

	public override void Spawn() {
		var obj = Pop();
		obj.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, -0.1f, Camera.main.nearClipPlane));
		obj.transform.localPosition = new Vector3 (obj.transform.position.x, obj.transform.position.y, 0);
	}
}
