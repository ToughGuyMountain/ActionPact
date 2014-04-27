using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Pool<T> : Singleton<Pool<T>> where T : PoolObject {
	private Stack<T> pool;
	[SerializeField] private T prefab;
	[SerializeField] private int size = 16; 
	[SerializeField] private List<T> activeObjects;
	public List<T> ActiveObjects { get { return activeObjects; } }

	protected override void Awake() {
		base.Awake();
		pool = new Stack<T>(size);
		activeObjects = new List<T>(size);
		Populate();
	}

	void OnEnable() {
		// give the Game instance a chance to exist on the first run
		StartCoroutine (_SubscribeAfterWait ());
	}

	void OnDisable() {
		MountainGame.Instance.end.Exit -= ReturnAfterWait;
	}

	IEnumerator _SubscribeAfterWait() {
		yield return new WaitForEndOfFrame();
		MountainGame.Instance.end.Exit += ReturnAfterWait;
	}
	
	public void ReturnAfterWait() {
		StartCoroutine (_ReturnAfterWait ());
	}
	
	IEnumerator _ReturnAfterWait() {
		yield return new WaitForEndOfFrame();
		ReturnAllToPool ();
	}

	private void Populate() {
		for (int i = 0; i < size; i++) {
			var obj = Instantiate(prefab) as T;
			obj.transform.parent = transform;
			obj.gameObject.SetActive(false);
			pool.Push(obj);
		}
	}

	public virtual void Spawn() {
		var obj = Pop();
		var value = UnityEngine.Random.value;
		//Debug.Log (value);
		obj.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-0.28f + value, -0.1f, Camera.main.nearClipPlane));
		obj.transform.localPosition = new Vector3 (obj.transform.position.x, obj.transform.position.y, 0);
	}

	public T Pop() {
		if (pool.Count > 0) {

			var obj = pool.Pop();
			obj.gameObject.SetActive(true); 
			activeObjects.Add(obj);
			return obj;
		}
		else {
			Debug.LogWarning("POOL LIMIT REACHED");
			return null;
		}
	}
	
	public void Push(T obj) {
		if (ActiveObjects.Contains(obj)) {
			obj.gameObject.SetActive(false);
			activeObjects.Remove(obj);
			pool.Push(obj);
		}
	}

	public virtual void ReturnAllToPool() {
		Debug.Log ("all back to pool");
		var activeCopy = ActiveObjects.GetRange(0, ActiveObjects.Count);
		Debug.Log (activeCopy.Count);
		foreach (var obj in activeCopy) {
			obj.ReturnToPool();
		}
	}
}