using UnityEngine;
using System.Collections;


public class FollowPlayer : MonoBehaviour {
	
	private GameObject target;
	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2.Lerp(this.transform.position, target.transform.position, speed*Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			Destroy(this.gameObject);
		}
	}
}
