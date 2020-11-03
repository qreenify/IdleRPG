using System;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPopUp : MonoBehaviour {
	public float movementSpeed = 5f;
	public float alphaFadeSpeed = 5f;
	
	void Update() {
		this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
		var text = GetComponent<Text>();
		var color = text.color;
		color.a -= this.alphaFadeSpeed * Time.deltaTime;
		text.color = color;
		if (color.a <= 0f) {
			Destroy(this.gameObject);
		}
	}
}