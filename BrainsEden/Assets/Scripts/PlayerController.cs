using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	Vector2 lastClickedPosition= new Vector2(0, Screen.height/2);
	public float moveSpeed=500.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0)
		{

			if(Input.touches[0].position.x > Screen.width*0.1f)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase==TouchPhase.Began || Input.touches[0].phase==TouchPhase.Moved){
					lastClickedPosition= Input.touches[0].position;
				}
				Debug.Log(Input.touches[0].position);
			}

		}


		float diff = transform.position.y - Camera.main.ScreenToWorldPoint(lastClickedPosition).y;
		if (diff < -moveSpeed*Time.deltaTime) {
			transform.Translate (0, moveSpeed*Time.deltaTime, 0);
		} else if (diff > moveSpeed*Time.deltaTime) {
			transform.Translate (0, -moveSpeed*Time.deltaTime, 0);
		} else {
			transform.Translate (0, -diff, 0);
		}
	}
}
