using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3 basePosition;
	public float shake;
	int shakeDirX, shakeDirZ;

	// Use this for initialization
	void Start () {
		//Almacena la posicion inicial de la camara, para volver a ella despues de vibrar
		basePosition = transform.position;
		shake = 0;
		shakeDirX = 1;
		shakeDirZ = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Aqui es donde vibra la camara
		if(shake>0.01f){
			transform.Translate((shakeDirX*shake*(20+Random.Range(0, 50))/100), (shakeDirZ*shake*(20+Random.Range(0, 50))/100), 0);
			shake-=Time.deltaTime;

			if(Random.Range(0, 2)==0){
				shakeDirX=-shakeDirX;
			}
			if(Random.Range(0, 2)==0){
				shakeDirZ=-shakeDirZ;
			}
		}

		//Para que la camara vuelva automaticamente a su lugar
		transform.Translate (-Mathf.Lerp (basePosition.x, transform.position.x, 0.1f), -Mathf.Lerp (basePosition.y, transform.position.y, 0.1f), 0);
	}

	//Este es el setter de la vibracion de la camara
	void SetShake(float amount) {
		if (amount > shake) {
			shake = amount;
		}
	}
}
