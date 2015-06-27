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

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLane) {
			if (transform.position.y > Camera.main.ScreenToWorldPoint (new Vector2 (0, Screen.height - 70)).y) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -speed * Time.deltaTime));
			} else if (transform.position.y < Camera.main.ScreenToWorldPoint (new Vector2 (0, 70)).y) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, speed * Time.deltaTime));
			} else if (transform.position.x < 100) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (speed * Time.deltaTime, 0));
			} else if (transform.position.x > 180) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-speed * Time.deltaTime, 0));
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				counter -= Time.deltaTime;
				if (counter <= 0) {
					Instantiate (bullet).transform.position = transform.position;
					counter = shootDelay;
				}

			}
		}

	}
}
