using UnityEngine;
using System.Collections;

public class caracteristicaDrone : MonoBehaviour 
{
	public float vida;
	public bool pausado= false;
	public bool muerto=false;

	public GameObject box;

	void Damage(float hp) {
		if (hp > 0.0f) {
			vida-=hp;
		}
		if (vida <= 0) {
			muerto=true;
			vida=0;
			AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
			Destroy(gameObject);
		}
	}
}
