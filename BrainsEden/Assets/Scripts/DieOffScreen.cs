using UnityEngine;
using System.Collections;

public class DieOffScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height+100 || screenPosition.y < -100 || screenPosition.x > Screen.width+100 || screenPosition.x < -100)
		{
			Destroy(gameObject);
		}
	}
}
