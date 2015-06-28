using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	public Image botonPlay;

	float esperaPlay;
	float contadorPlay;
	bool cambiaScene;
	bool empieza;

	void Start() {
		esperaPlay = 0.5f;
		contadorPlay = 0f;
		cambiaScene = false;
		empieza = false;
	}

	void Update() {
		if (empieza) {
			if (contadorPlay < esperaPlay) {
				contadorPlay += Time.deltaTime;
			} else {
				cambiaScene = true;
				contadorPlay = 0f;
			}
			
			if(cambiaScene)	{
				Application.LoadLevel ("GameScene");
			}
		}
	}

	public void OnPlayClicked() {     //COMO ESTABA ANTES
		empieza = true;
		//GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_play.Play ();
		GameObject.Find ("FadeEffect").GetComponent<FadeScript> ().fadeOut(new Color(0,0,0), 0.8f);
	}
}
	/*public Image panel_creditos;
	public Image boton_volver;
	public Image boton_play;
	public Image logo;

	bool cambiaScene;
	bool empieza;
	
	// Use this for initialization
	void Start () {
		cambiaScene = false;
		empieza = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (empieza) {
			if (contadorPlay < esperaPlay) {
				contadorPlay += Time.deltaTime;
			} else {
				cambiaScene = true;
				contadorPlay = 0f;
			}
			
			if(cambiaScene)	{
				Application.LoadLevel ("MainScene");
			}
		}
	}
	
	public void OnPlayClicked() {     //COMO ESTABA ANTES
		empieza = true;
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_play.Play ();
		fadeOut ();
	}
	
	public void OnCreditClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_button.Play ();
		panel_creditos.enabled = true;
		boton_volver.enabled = true;
		logo.enabled = false;
		boton_play.enabled = false;
	}
	
	public void OnVolverClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_button.Play ();
		panel_creditos.enabled = false;
		panel_tutorial.enabled = false;
		boton_volver.enabled = false;
		logo.enabled = true;
		boton_play.enabled = true;
	}
	
	public void OnTutorialClicked() {
		GameObject.Find ("AudioObject").GetComponent<LoadAudio>().click_button.Play ();
		panel_tutorial.enabled = true;
		boton_volver.enabled = true;
		logo.enabled = false;
		boton_play.enabled = false;
	}
	
	IEnumerator fadeOut() {
		// Aplicamos el Fade
		float fadeTime = GetComponent<Fading> ().BeginOut ();
		yield return new WaitForSeconds (fadeTime);
	}*/
