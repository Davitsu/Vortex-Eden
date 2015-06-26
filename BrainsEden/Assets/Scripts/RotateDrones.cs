using UnityEngine;
using System.Collections;

public class RotateDrones : MonoBehaviour {

	public float rotationSpeed = 250.0f;
	public float orbitDistance = 50.0f;
	public GameObject prefabToBeRotated;
	private GameObject[] drones = new GameObject[42];
	private GameObject[] anchors = new GameObject[42];
	private Vector2[] anchorPoints = new Vector2[42];

	// Use this for initialization
	void Start () {
		drones = GameObject.FindGameObjectsWithTag (prefabToBeRotated.tag);
		int anchorNumber = drones.Length;
		float radiusDifference = 360 / anchorNumber;
		float currentRadius = 0.0f;
		for (int i = 0; i < anchorNumber; i++) {
			float radians = Mathf.Deg2Rad*currentRadius;
			Vector2 direction = new Vector2((float)Mathf.Cos(radians), -(float)Mathf.Sin(radians));
			direction.Normalize();
			Vector2 relativePoint = direction * orbitDistance;
			Vector2 point = new Vector2(this.transform.position.x + relativePoint.x, this.transform.position.y + relativePoint.y);

			anchorPoints[i] = point;
			anchors[i] = new GameObject();
			anchors[i].transform.position = anchorPoints[i];
			currentRadius += radiusDifference;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < drones.Length; i++) {
			//rota el ancla del dron
			anchors[i].transform.RotateAround(this.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
			//dron sigue al ancla
			drones[i].transform.position = Vector3.Lerp(drones[i].transform.position, anchors[i].transform.position, Time.deltaTime*2.5f);
		}
	}
}
