using UnityEngine;
using System.Collections;

public class MeleeBehavior : MonoBehaviour {
	
	public float speed = 5000.0f;
	public float laneSpeed = 40.0f;
	public float hitDelay = 3.0f;
	public float damage = 5.0f;
	float counter=0.0f;
	int lane;
	Vector2 destiny;
	bool hasLane = false;
	bool startWalking = false;
	bool attacking = false;
	GridScript grid;
	GameObject player;
	GameObject drone;
	Animator animator;

	// Use this for initialization
	void Start () {
		destiny.x = 150;
		grid=GameObject.FindGameObjectWithTag ("Grid").GetComponent<GridScript>();
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = this.GetComponentInChildren<Animator>();
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
					if(attacking){
						if(drone==null){
							animator.SetBool("attacking", false);
							attacking=false;
						}
						else{
							counter -= Time.deltaTime;
							if (counter <= 0) {
								drone.SendMessage("Damage", damage);
								counter = hitDelay;
							}
						}
					}
					else{
						destiny.x-=laneSpeed*Time.deltaTime;
					}
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
		else if(other.gameObject.tag == "Drone"){
			drone = other.gameObject;
			attacking = true;
			animator.SetBool("attacking", true);
		}
	}

	void OnDestroy() {
		grid.laneAvailable[lane]=true;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().addPuntuacion(100);
	}
}
