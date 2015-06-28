using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed=80.0f;
	public Vector2 direction;
	public bool wiggle;
	public float wiggleWidth=0.1f;
	public float wiggleFreq=20.0f;
	float timeCreated;
	bool fallingOff=false;

	// Use this for initialization
	void Start () {
		timeCreated = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fallingOff) {
			transform.Translate (direction * speed * Time.deltaTime);
			if (wiggle) {
				direction.y = wiggleWidth * Mathf.Sin ((Time.time - timeCreated) * wiggleFreq) * wiggleFreq;
			}
		}
	}

	public void FallOff(){
		fallingOff = true;
		GetComponent<Rigidbody2D>().gravityScale=50.0f;
		GetComponent<Rigidbody2D> ().freezeRotation = false;
		GetComponent<Rigidbody2D> ().angularVelocity=(Random.Range (-1000.0f, 1000.0f));
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (40.0f, 80.0f), Random.Range (-20.0f, 20.0f)), ForceMode2D.Impulse);
	}
}
