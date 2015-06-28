using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {

	public GameObject bullet;
	public float speed = 5000.0f;
	public float shootDelay=3.0f;
	float counter=0.0f;
	int lane;
	Vector2 destiny;
	bool hasLane=false;
	GridScript grid;

	// Use this for initialization
	void Start () {
		destiny.x = 170;
		grid=GameObject.FindGameObjectWithTag ("Grid").GetComponent<GridScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLane) {
			Vector2 pos= transform.position;
			Vector2 dif= pos-destiny;
			if (dif.magnitude>0.1f){
				GetComponent<Rigidbody2D>().AddForce(-dif.normalized*speed*Time.deltaTime);
			} else {

				counter -= Time.deltaTime;
				if (counter <= 0) {
					Instantiate (bullet).transform.position = transform.position;
					counter = Random.Range(0.7f, 1.3f)*shootDelay;
				}
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

	void OnDestroy() {
		grid.laneAvailable[lane]=true;
	}
}
