using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth=10.0f;
	float health;
	bool dead=false;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Damage(float hp) {
		if (hp > 0.0f) {
			health-=hp;
		}
		if (health <= 0) {
			dead=true;
			health=0;
		}
	}

	void Heal(float hp){
		if (!dead && hp > 0.0f) {
			health+=hp;
			if (health > maxHealth) {
				health=maxHealth;
			}
		}
	}

	bool isDead(){
		return dead;
	}
}
