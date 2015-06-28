using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	public Image botonPlay;
	public Image panel_credits;
	public Image panel_tutorial;
	public Image boton_volver;
	public Image logo;
	public Image boton_play;
	public Image boton_tutorial;
	public Image texto_vortex;
	public Image texto_be;

	float esperaPlay;
	float contadorPlay;
	bool cambiaScene;
	bool empieza;

	void Start() {
		esperaPlay = 1.5f;
		contadorPlay = 0f;
		cambiaScene = false;
		empieza = false;
	}

	void Update() {
		if (empieza) {
			if(GameObject.Find ("FadeEffect").GetComponent<FadeScript> ().fadeOut(new Color(0,0,0), 1.5f)) {
				Application.LoadLevel ("GameScene");
			}
		}
	}

	public void OnPlayClicked() { 
		empieza = true;
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_play.Play ();
		GameObject.Find ("FadeEffect").GetComponent<FadeScript> ().fadeOut(new Color(0,0,0), 0.8f);
	}

	public void OnCreditClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio> ().click_button.Play ();
		panel_credits.enabled = true;
		boton_volver.enabled = true;
		logo.enabled = false;
		boton_play.enabled = false;
		texto_vortex.enabled = false;
		texto_be.enabled = false;
	}

	public void OnBackClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_back.Play ();
		panel_credits.enabled = false;
		panel_tutorial.enabled = false;
		boton_volver.enabled = false;
		logo.enabled = true;
		boton_play.enabled = true;
		texto_vortex.enabled = true;
		texto_be.enabled = true;
	}

	public void OnTutorialClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_button.Play ();
		panel_tutorial.enabled = true;
		boton_volver.enabled = true;
		logo.enabled = false;
		boton_play.enabled = false;
		texto_vortex.enabled = false;
		texto_be.enabled = false;
	}
}
