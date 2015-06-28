using UnityEngine;
using System.Collections;

public class KamikazeScript : MonoBehaviour {

	public float speed = 5;
	public int wanderingTime = 3;
	float wanderingCounter = 0;

	private GridScript grid;
	private Rect enemyArea;

	private Vector2 wanderingPoint1;
	private Vector2 wanderingPoint2;
	
	private int timeToPoint1;
	private int timeToPoint2;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GridScript>();
		enemyArea = grid.enemyArea;

		float xCoordinate = Random.Range (enemyArea.xMin, enemyArea.xMax-GetComponent<SpriteRenderer>().sprite.bounds.size.x/1.5f);
		float yCoordinate = Random.Range (enemyArea.yMin, enemyArea.yMax-GetComponent<SpriteRenderer>().sprite.bounds.size.y/1.5f);
		wanderingPoint1 = new Vector2 (xCoordinate, yCoordinate);

		xCoordinate = Random.Range (enemyArea.xMin, enemyArea.xMax - GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.5f);
		yCoordinate = Random.Range (enemyArea.yMin + GetComponent<SpriteRenderer>().sprite.bounds.size.y/1.5f, enemyArea.yMax - GetComponent<SpriteRenderer>().sprite.bounds.size.y/1.5f);
		wanderingPoint2 = new Vector2(xCoordinate, yCoordinate);

		direction = new Vector2 (0, 0);

		timeToPoint1 = wanderingTime / 2;
		timeToPoint2 = wanderingTime;
	}

	void Wander(int point){
		if (point == 1) {
			this.transform.position = Vector2.Lerp(this.transform.position, wanderingPoint1, Time.deltaTime);
			Debug.Log("moviendo a 1");
		} else {
			this.transform.position = Vector2.Lerp(this.transform.position, wanderingPoint2, Time.deltaTime);
			Debug.Log("moviendo a 2");
		}
	}

	void Suicide(){
		if (direction == Vector2.zero) {
			GameObject player = GameObject.FindGameObjectWithTag ("Jugador");
			direction = player.transform.position - this.transform.position;
			direction.Normalize();
		} else {
			transform.Translate(direction.x*speed*2*Time.deltaTime, direction.y*speed*2*Time.deltaTime, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Jugador"))
			Destroy (this.gameObject);
		//crear explosion
	}	

	void OnTriggerEnter2D(Collider2D other){

	}
	
	// Update is called once per frame
	void Update () {
		if (wanderingCounter < timeToPoint1) {
			Wander(1);
		} else if (wanderingCounter < timeToPoint2) {
			Wander(2);
		} else {
			Suicide();
		}

		wanderingCounter += Time.deltaTime;
	}
}
