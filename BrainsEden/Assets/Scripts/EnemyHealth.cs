using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth=10.0f;
	public float energyYield=2.0f;
	public float flickerTime;
	float health;
	bool dead=false;
	float redCounter;
	Color flickerColor;
	public GameObject prefabDrops;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		flickerColor = new Color (1.0F, 0.5F, 0.5F, 1.0F);
	}
	
	// Update is called once per frame
	void Update () {
		if (redCounter > 0) {
			redCounter -= Time.deltaTime;
			if (redCounter < (1 * flickerTime / 5)) {
				GetComponentInChildren<SpriteRenderer> ().color = flickerColor;
			} else if (redCounter < (2 * flickerTime / 5)) {
				GetComponentInChildren<SpriteRenderer> ().color = Color.white;
			} else if (redCounter < (3 * flickerTime / 5)) {
				GetComponentInChildren<SpriteRenderer> ().color = flickerColor;
			} else if (redCounter < (4 * flickerTime / 5)) {
				GetComponentInChildren<SpriteRenderer> ().color = Color.white;
			} else {
				GetComponentInChildren<SpriteRenderer> ().color = flickerColor;
			}
		} else {
			GetComponentInChildren<SpriteRenderer> ().color = Color.white;
		}
	}

	void Damage(float hp) {
		if (hp > 0.0f) {
			GetComponentInChildren<SpriteRenderer>().color=flickerColor;
			redCounter=flickerTime;
			health-=hp;
		}
		if (health <= 0) {
			dead=true;
			health=0;
			AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
			GameObject.FindGameObjectWithTag("GameController").SendMessage("addEnergy", energyYield);
			Instantiate(prefabDrops, transform.position, transform.rotation);
			Destroy(gameObject);
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
