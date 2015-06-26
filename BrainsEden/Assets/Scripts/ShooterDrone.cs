using UnityEngine;
using System.Collections;

public class ShooterDrone : MonoBehaviour {

	public float vida;

	void Awake()
	{
		vida= 10;
	}

	// Use this for initialization	
	void Start () 
	{
		StartCoroutine(Disparar());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(vida <= 0f)
			Destroy(this.gameObject);
	}

	IEnumerator Disparar()
	{
		while(true)
		{
			StartCoroutine(Rafaga());
			yield return new WaitForSeconds(1f);
		}
	}
	
	IEnumerator Rafaga()
	{
		for(int i=0; i < 3; i++)
		{
			Debug.Log("BANG!");
			yield return new WaitForSeconds(0.1f);
		}
	}
}
