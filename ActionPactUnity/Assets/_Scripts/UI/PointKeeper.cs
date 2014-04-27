using UnityEngine;
using System.Collections;

public class PointKeeper : MonoBehaviour {
	public ShoppingCartBros bro;
	UILabel label;

	void Start () {
		label = GetComponent<UILabel>();
	}

	void Update () {
		label.text = bro.brewCount.ToString();
	}
}
