using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {
	
	public Sprite grafico;
	public CircleCollider2D colision;
	
	public float radio;
	public float velocidad;
	
	void Awake () {
		//ajustes collider
		colision.radius= 0f;

		//ajustes sprite
		//aqui
	}
	
	// Update is called once per frame
	void Update () {
		//crecimiento y muerte
		if(colision.radius <= radio)
		{
			colision.radius+= velocidad * Time.deltaTime;
		}
		else{
			Destroy(this.gameObject);
		}
	}
}
