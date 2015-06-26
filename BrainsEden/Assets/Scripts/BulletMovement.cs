using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed=50.0f;
	public Vector2 direction;
	public float wiggleWidth=0.1f;
	public float wiggleFreq=20.0f;

	// Use this for initialization
	void Start () {
		direction = Vector2.right;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * speed*Time.deltaTime);
		direction.y = wiggleWidth*Mathf.Sin (Time.time*wiggleFreq)*wiggleFreq;
	}
}
