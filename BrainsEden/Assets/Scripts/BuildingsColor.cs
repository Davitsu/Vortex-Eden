using UnityEngine;
using System.Collections;

public class BuildingsColor : MonoBehaviour {
	GameObject[] background0, background1;
	public float speed = 50;
	public float speed2 = 100;

	// Use this for initialization
	void Start () {
		background0 = new GameObject[2];
		background0[0] = GameObject.Find ("buildings_00");
		background0[1] = GameObject.Find ("buildings_01");
		background0 [1].transform.position = new Vector3 (background0 [1].transform.position.x - 399, background0 [1].transform.position.y, background0 [1].transform.position.z);

		background1 = new GameObject[2];
		background1[0] = GameObject.Find ("buildings_10");
		background1[1] = GameObject.Find ("buildings_11");
		background1[1].transform.position = new Vector3 (background1 [1].transform.position.x - 399, background1 [1].transform.position.y, background1 [1].transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i<background0.Length; i++) {
			background0[i].transform.position = new Vector3(background0[i].transform.position.x + speed * Time.deltaTime, background0[i].transform.position.y, background0[i].transform.position.z);
			if(background0[i].transform.position.x > 420) {
				background0[i].transform.position = new Vector3(background0[i].transform.position.x - 798, background0[i].transform.position.y, background0[i].transform.position.z);
			}
		}

		for(int i=0; i<background1.Length; i++) {
			background1[i].transform.position = new Vector3(background1[i].transform.position.x + speed2 * Time.deltaTime, background1[i].transform.position.y, background1[i].transform.position.z);
			if(background1[i].transform.position.x > 420) {
				background1[i].transform.position = new Vector3(background1[i].transform.position.x - 798, background1[i].transform.position.y, background1[i].transform.position.z);
			}
		}
	}
}
