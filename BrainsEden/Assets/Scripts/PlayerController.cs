using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	Vector2 lastClickedPosition= new Vector2(0, Screen.height/2);
	public float moveSpeed=500.0f;
	public GameObject playerBullet;
	public float shootingSpeed=40.0f;
	float counter;

	// Use this for initialization
	void Start () {
		counter = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR_WIN
		if (Input.GetMouseButton(0)){
			if(Input.mousePosition.x > Screen.width*0.1f)	//posicion en coordenadas de world
			{
				lastClickedPosition= Input.mousePosition;
				
				if(counter<=0){
					Instantiate(playerBullet).transform.position=transform.position;
					counter=1.0f/shootingSpeed;
				}
			}
			
		}
		#elif UNITY_ANDROID
		if(Input.touchCount > 0)
		{

			if(Input.touches[0].position.x > Screen.width*0.1f)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase==TouchPhase.Began || Input.touches[0].phase==TouchPhase.Moved){
					lastClickedPosition= Input.touches[0].position;
				}

				if(counter<=0){
					Instantiate(playerBullet).transform.position=transform.position;
					counter=1.0f/shootingSpeed;
				}
				else{
					counter-=Time.deltaTime;
				}
			}

		}
		#else
		if (Input.GetMouseButton(0)){
			if(Input.mousePosition.x > Screen.width*0.1f)	//posicion en coordenadas de world
			{
				lastClickedPosition= Input.mousePosition;
				
				if(counter<=0){
					Instantiate(playerBullet).transform.position=transform.position;
					counter=1.0f/shootingSpeed;
				}
			}

		}
		#endif

		counter-=Time.deltaTime;

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
