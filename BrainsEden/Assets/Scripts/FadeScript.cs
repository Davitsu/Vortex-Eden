using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {
	public Texture2D texture;
	Color color;
	float alphaIn = 1.0f;
	float alphaOut = 0.0f;
	int depth = -1000;

	// Use this for initialization
	void Start () {
		color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Desaparece la escena, aparece fade
	public bool fadeOut (Color nColor, float speed) {
		bool res = false;

		alphaOut += speed * Time.deltaTime;
		if (alphaOut >= 1.0f) {
			alphaOut = 1.0f;
			res = true;
		}

		color = new Color(nColor.r, nColor.g, nColor.b, alphaOut);
		return res;
	}

	// Aparece la escena, quita fade
	public bool fadeIn (Color nColor, float speed) {
		bool res = false;

		alphaIn -= speed * Time.deltaTime;
		if (alphaIn <= 0.0f) {
			alphaIn = 0.0f;
			res = true;
		}
		
		color = new Color(nColor.r, nColor.g, nColor.b, alphaIn);
		return res;
	}

	void OnGUI() {
		GUI.color = color;
		GUI.depth = depth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texture);
	}
}
