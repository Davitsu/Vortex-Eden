using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	public bool taken = false;
	public int id;
	public GameObject dron;

	// Use this for initialization
	void Start () {
		dron = null;
	}

	public void SetDrone(GameObject drone){
		dron = drone;
	}

	// Update is called once per frame
	void Update () {
		
	}

	#region funciones publicas
	public void Generate(int id, float scaleX, float scaleY) {
		this.transform.localScale = new Vector3 (scaleX, scaleY, 1);
		this.id = id;
	}
	#endregion
}
