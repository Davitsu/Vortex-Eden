using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {

	public int columns = 14;
	public int rows = 10;
	public float bottom = 0.0f;
	public float left = 0.0f;
	public float width = 1;	//de 0 a 1
	public float height = 1;
	public GameObject tilePrefab;
	private GameObject[] boxes = new GameObject[42];

//	public BoxScript boxScript;

	// Use this for initialization
	void Start () {

		if (width > 1)
			width = 1;
		if (height > 1)
			height = 1;

		float worldHeight =  2f * Camera.main.orthographicSize;
		float worldWidth = worldHeight * Camera.main.aspect;

//		int numberOfBoxes = columns * rows;
		float boxWidth = (worldWidth * width) / columns;
		float boxHeight = (worldHeight * height) / rows;

		Vector3 worldBottomLeft = new Vector3(-worldWidth / 2 + boxWidth/2, -worldHeight/2 + boxHeight/2, 0);

//		Vector2 upperLeftCorner = new Vector2 (-screenWidth / 2, -screenHeight / 2);
		int counter = 0;
		for(int i = 0; i < columns; i++)
		{
			for(int j = 0; j < rows; j++)
			{
				GameObject box = (GameObject)Instantiate(tilePrefab, worldBottomLeft + new Vector3(i*boxWidth+left, j*boxHeight+bottom, 0), tilePrefab.transform.rotation);
				boxes[counter] = box;
				BoxScript boxScript = box.GetComponent<BoxScript>();
				boxScript.Generate(counter, boxWidth, boxHeight);
				counter++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#region funciones publicas
	public void EnableFreeBoxes()
	{
		foreach(GameObject box in boxes)
		{
			if(!box.GetComponent<BoxScript>().taken)
				box.SetActive(true);
		}
	}

	public void DisableBoxes()
	{
		foreach(GameObject box in boxes)
		{
			box.SetActive(false);
		}
	}
	#endregion
}
