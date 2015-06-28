using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {
	
	public Sprite grafico;
	public float damage;
	
	public float radio;
	public float velocidad;
	public float lifetime;

	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if(lifetime <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy"){
			other.gameObject.SendMessage("Damage", damage);
		}
	}
}
