using UnityEngine;
using System.Collections;

public class HurtEnemies : MonoBehaviour {

	public float damage=1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy"){
			other.gameObject.SendMessage("Damage", damage);
			Destroy(gameObject);
		}
	}
}
