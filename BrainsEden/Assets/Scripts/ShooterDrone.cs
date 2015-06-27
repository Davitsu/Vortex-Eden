using UnityEngine;
using System.Collections;

public class ShooterDrone : MonoBehaviour {

	public GameObject balaPrefab;
	
	public GameObject boxPosition;
	
	public float vida = 10;
	
	public float disparaCada= 0.75f;
	float contadorDisparo= 0f;
	
	// Update is called once per frame
	void Update () 
	{	
		//control disparo
		contadorDisparo+= Time.deltaTime;
		
		if(contadorDisparo >= disparaCada){
			StartCoroutine(Rafaga ());
			contadorDisparo= 0f;
		}
		
		//control vida
		if(vida <= 0f)
		{
			Destroy(this.gameObject);
			boxPosition.GetComponent<BoxScript>().taken= false;
		}
	}
	
	IEnumerator Rafaga()
	{
		for(int i=0; i < 3; i++)
		{
			Instantiate(balaPrefab, this.gameObject.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(0.15f);
		}
	}
	
	void Disparo(){
		Instantiate(balaPrefab, this.gameObject.transform.position, Quaternion.identity);
	}
}
