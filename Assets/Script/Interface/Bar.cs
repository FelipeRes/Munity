﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bar : MonoBehaviour {

	private Image image;
	public float value;
	public bool IncrementLeftToRight;
	private Vector2 lifeAnchorMax;
	private Vector2 lifeAnchorMin;
	private Vector2 positionMax;
	private Vector2 positionMin;
	private float intervalo;
	private Color color;
	void Start () {
		image = this.GetComponent<Image> ();
		lifeAnchorMax = image.rectTransform.anchorMax;
		lifeAnchorMin = image.rectTransform.anchorMin;
		positionMax = image.rectTransform.anchorMax;
		positionMin = image.rectTransform.anchorMin;
		intervalo = image.rectTransform.anchorMin.x - image.rectTransform.anchorMax.x;
		color = this.image.color;
	}

	void Update () {
		if (IncrementLeftToRight) {
			lifeAnchorMax.x = positionMin.x - intervalo * value;
			image.rectTransform.anchorMax = lifeAnchorMax;
		} else {
			lifeAnchorMin.x = positionMax.x + intervalo * value;
			image.rectTransform.anchorMin = lifeAnchorMin;
		}
	}
	public void SetColor(Color color){
		image.color = color;
	}
	public void RestoreColor(){
		image.color = this.color;
	}
}
