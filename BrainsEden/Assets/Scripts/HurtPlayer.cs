using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	public float damage=1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Drone"){
			other.gameObject.SendMessage("Damage", damage);
			Destroy(gameObject);
		}
	}
}
