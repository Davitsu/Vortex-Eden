using UnityEngine;
using System.Collections;

public class ShootaBehavior : MonoBehaviour {

	public GameObject bullet;
	public float speed = 5000.0f;
	public float burstDelay=3.0f;
	public float burstDuration=1.0f;
	public float shootingSpeed=5.0f;
	float counter=0.0f;
	bool shooting;
	float burst;
	float moving;

	// Use this for initialization
	void Start () {
		burst=burstDuration;
		moving=burstDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting) {
			GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
			counter -= Time.deltaTime;
			burst -= Time.deltaTime;
			if (counter <= 0) {
				Instantiate (bullet).transform.position = transform.position;
				counter = 1.0f / shootingSpeed;
			}
			if(burst<=0){
				shooting=false;
				burst=burstDuration;
			}

		} else {
			if(transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0,Screen.height-70)).y ){
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -speed * Time.deltaTime));
			} else if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(0,70)).y ) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * Time.deltaTime));
			} else if (transform.position.x < 100) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Time.deltaTime, 0));
			} else if (transform.position.x > 180) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed * Time.deltaTime, 0));
			} else {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2.0f,2.0f)*speed*Time.deltaTime, Random.Range(-2.0f,2.0f)*speed*Time.deltaTime));
			}
			moving -= Time.deltaTime;
			if(moving<=0){
				shooting=true;
				moving=burstDelay;
			}
		}
	}
}
