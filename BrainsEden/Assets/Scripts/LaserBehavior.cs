using UnityEngine;
using System.Collections;

public class LaserBehavior : MonoBehaviour {

	public GameObject bullet;
	public float speed = 5000.0f;
	public float shootDelay;
	float counter=0.0f;
	int lane;
	Vector2 destiny;
	bool hasLane=false;
	GridScript grid;
	Animator animator;
	float contadorAni = 0;

	// Use this for initialization
	void Start () {
		destiny.x = 170;
		grid=GameObject.FindGameObjectWithTag ("Grid").GetComponent<GridScript>();
		animator = this.GetComponentInChildren<Animator>();
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
					animator.SetBool("attacking", true);
					contadorAni = 3;
					Instantiate (bullet).transform.position = transform.position;
					counter = Random.Range(0.7f, 1.3f)*shootDelay;
				}
			}
		} else {
			lane=Random.Range(0, grid.lanes.Length);
			if(grid.laneAvailable[lane]){
				grid.laneAvailable[lane]=false;
				destiny.y=grid.lanes[lane];
				hasLane=true;
			}
		}
		if (contadorAni > 0) {
			contadorAni -= Time.deltaTime*5;
			if(contadorAni <= 0) {
				animator.SetBool("attacking", false);
			}
		}
	}

	void OnDestroy() {
		grid.laneAvailable[lane]=true;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().addPuntuacion(100);
	}
}
