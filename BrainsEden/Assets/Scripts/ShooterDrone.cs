using UnityEngine;
using System.Collections;

public class ShooterDrone : MonoBehaviour {

	public GameObject balaPrefab;
	
	public GameObject boxPosition;
	public caracteristicaDrone datos;

	
	public float disparaCada;
	float contadorDisparo= 0f;
	
	// Update is called once per frame
	void Update () 
	{	
		if(!datos.pausado)
		{
			//control disparo
			contadorDisparo+= Time.deltaTime;
			
			if(contadorDisparo >= disparaCada)
			{
				Disparo();
				contadorDisparo= 0f;
			}
		}
		
		//control vida
		if(datos.vida <= 0f)
		{
			boxPosition.GetComponent<BoxScript>().taken= false;
			Destroy(this.gameObject);
		}
	}
	
	void Disparo(){
		Instantiate(balaPrefab, this.gameObject.transform.position, Quaternion.identity);
	}
}
