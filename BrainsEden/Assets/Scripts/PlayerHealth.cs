using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth=100.0f;
	public float flickerTime;
	public float health;
	bool dead=false;
	float redCounter;
	Color flickerColor;

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

	public void Damage(float hp) {
		if (hp > 0.0f) {
			Camera.main.GetComponent<CameraController>().SetShake (2.0f);
			GetComponentInChildren<SpriteRenderer>().color=flickerColor;
			redCounter=flickerTime;
			health-=hp;
		}
		if (health <= 0) {
			dead=true;
			health=0;
			AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
		}
	}

	public void Heal(float hp){
		if (!dead && hp > 0.0f) {
			health+=hp;
			if (health > maxHealth) {
				health=maxHealth;
			}
		}
	}

	public bool isDead(){
		return dead;
	}
}
