using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	FadeScript fade;

	// Use this for initialization
	void Start () {
		fade = GameObject.Find ("FadeEffect").GetComponent<FadeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		fade.fadeIn (new Color (0, 0, 0), 0.8f);

		/*if (res) {
			res = fade.fadeOut (new Color (0, 0, 0), 0.8f);

			if(res) {
				Application.LoadLevel("DavidScene2");
			}
		}*/
	}
}
