using UnityEngine;
using System.Collections;

public class flameScript : MonoBehaviour {

	private ParticleSystem sistPart;

	// Use this for initialization
	void Awake ()
	{
		sistPart = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

//si se ejecuta en el editor (solamente)
#if UNITY_EDITOR	
		if (Input.GetKeyDown(KeyCode.Space)){
			switchFuego(0);
		} 
		if(Input.GetKeyUp(KeyCode.Space)){
			switchFuego(0);
		}
#endif

//si se ejecuta en una build de android o en el editor (tambien entra en el editor, segun unity es para hacer pruebas)
#if UNITY_ANDROID
		//esto es si la plataforma de ejecucion es Android (solamente), OJO!!!-> NO ES LO MISMO QUE LO ANTERIOR
		if(Application.platform == RuntimePlatform.Android){
			if (Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Ended)
					switchFuego(1);
			}
		}
#endif
	}

	void switchFuego(int flag){
		if (sistPart.enableEmission) {
			sistPart.enableEmission = false;
		} else {
			sistPart.enableEmission = true;
		}
		Debug.Log ("ESTADO: " + sistPart.enableEmission + " DISPOSITIVO: " + flag);
	}
}
