using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	GameObject[] background;
	public float background_speed = 800;

	// Use this for initialization
	void Start () {
		background = new GameObject[8];
		background [0] = GameObject.Find ("background_0");
		background [1] = GameObject.Find ("background_1");
		background [2] = GameObject.Find ("background_2");
		background [3] = GameObject.Find ("background_3");
		background [4] = GameObject.Find ("background_4");
		background [5] = GameObject.Find ("background_5");
		background [6] = GameObject.Find ("background_6");
		background [7] = GameObject.Find ("background_7");

		background [1].transform.position = new Vector3 (background [1].transform.position.x, background [0].transform.position.y + 499, background [1].transform.position.z);
		background [2].transform.position = new Vector3 (background [2].transform.position.x, background [0].transform.position.y + 998, background [2].transform.position.z);
		background [3].transform.position = new Vector3 (background [3].transform.position.x, background [0].transform.position.y + 1497, background [3].transform.position.z);
		background [4].transform.position = new Vector3 (background [4].transform.position.x, background [0].transform.position.y + 1996, background [4].transform.position.z);
		background [5].transform.position = new Vector3 (background [5].transform.position.x, background [0].transform.position.y + 2495, background [5].transform.position.z);
		background [6].transform.position = new Vector3 (background [6].transform.position.x, background [0].transform.position.y + 2994, background [6].transform.position.z);
		background [7].transform.position = new Vector3 (background [7].transform.position.x, background [0].transform.position.y + 3493, background [7].transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < background.Length; i++) {
			background [i].transform.position = new Vector3 (background [i].transform.position.x, background [i].transform.position.y - background_speed * Time.deltaTime, background [i].transform.position.z);
			if (background [i].transform.position.y < -499) {
				background [i].transform.position = new Vector3 (background [i].transform.position.x, background [i].transform.position.y + 3493, background [i].transform.position.z);
			}
		}
	}
}
