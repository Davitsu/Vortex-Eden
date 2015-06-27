using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed=80.0f;
	public Vector2 direction;
	public bool wiggle;
	public float wiggleWidth=0.1f;
	public float wiggleFreq=20.0f;
	float timeCreated;

	// Use this for initialization
	void Start () {
		timeCreated = Time.time;
		direction = Vector2.right;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed*Time.deltaTime);
		if (wiggle) {
			direction.y = wiggleWidth * Mathf.Sin ((Time.time-timeCreated) * wiggleFreq) * wiggleFreq;
		}
	}
}
