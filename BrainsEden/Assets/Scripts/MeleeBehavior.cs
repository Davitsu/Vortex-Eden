﻿using UnityEngine;
using System.Collections;

public class MeleeBehavior : MonoBehaviour {
	
	public float speed = 5000.0f;
	public float laneSpeed = 40.0f;
	public float hitDelay=3.0f;
	public float damage = 5.0f;
	float counter=0.0f;
	int lane;
	Vector2 destiny;
	bool hasLane=false;
	bool startWalking=false;
	GridScript grid;
	GameObject player;

	// Use this for initialization
	void Start () {
		destiny.x = 120;
		grid=GameObject.FindGameObjectWithTag ("Grid").GetComponent<GridScript>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLane) {
			Vector2 pos= transform.position;
			Vector2 dif= pos-destiny;

			if(pos.x< -100){
				Vector2 playerpos=player.transform.position;
				destiny=playerpos;
			}
			else{
				if(startWalking){
					destiny.x-=laneSpeed*Time.deltaTime;
					/*else {
					counter -= Time.deltaTime;
					if (counter <= 0) {
						counter = hitDelay;
					}
					}*/
				}
			}

			if (dif.magnitude>0.3f){
				GetComponent<Rigidbody2D>().AddForce(-dif.normalized*speed*Time.deltaTime);
			}
			else{
				startWalking=true;
			}
		} else {
			lane=Random.Range(0, 6);
			if(grid.laneAvailable[lane]){
				grid.laneAvailable[lane]=false;
				destiny.y=grid.lanes[lane];
				hasLane=true;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player"){
			other.gameObject.SendMessage("Damage", damage);
			Destroy(gameObject);
		}
	}

	void OnDestroy() {
		grid.laneAvailable[lane]=true;
	}
}
