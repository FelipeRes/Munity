using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallete : MonoBehaviour {

	public Color[] originalColor;
	public Color[] modifyColor;

	public Texture2D originalTexture;
	public Texture2D targetTexture;

	void Start () {
		CopyTexture2D (originalTexture, targetTexture);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CopyTexture2D (Texture2D originalTexture, Texture2D palleteTexture){
		for (int x =0; x < originalTexture.width; ++x) {
			for (int y =0; y < originalTexture.height; ++y) {
				for(int i=0; i< originalColor.Length; i++){
					if (originalTexture.GetPixel (x, y) == originalColor[i]) {
						palleteTexture.SetPixel (x, y, modifyColor [i]);
					}
				}

			}
		}
		palleteTexture.Apply ();
	}
}
