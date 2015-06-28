using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject[] enemiesToSpawn;
	public float delay= 15.0f;
	float counter= 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		if (counter <= 0) {
			counter=delay;
			Instantiate(enemiesToSpawn[Random.Range(0,enemiesToSpawn.Length)]).transform.position=transform.position;
			if(delay>1.0f){
				delay-=0.1f;
			}
		}
	}
}
