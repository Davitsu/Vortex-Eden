using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	public float damage=1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Drone"){
			if(!(other.gameObject.name.Contains("MirrorDrone") && gameObject.name.Contains("LaserBullet"))){
				if((other.gameObject.name.Contains("CannonDrone") && gameObject.name.Contains("ArrowBullet"))){
					SendMessage("FallOff");
					Destroy(this);
				}
				else if((other.gameObject.name.Contains("MineDrone") && gameObject.name.Contains("ArrowBullet"))){
					other.gameObject.SendMessage("Damage", 100);
					Destroy(this);
					Debug.Log("Boom");
				}
				else{
				other.gameObject.SendMessage("Damage", damage);
				Destroy(gameObject);
				}
			}
		}
	}
}
