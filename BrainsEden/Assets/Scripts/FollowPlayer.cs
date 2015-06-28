using UnityEngine;
using System.Collections;


public class FollowPlayer : MonoBehaviour {
	
	private GameObject target;
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position-target.transform.position).magnitude<2.0f){
			Destroy(this.gameObject);
		}
		Debug.Log (transform.position);
		transform.position=Vector2.Lerp(transform.position, target.transform.position, speed*Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){

	}
}
