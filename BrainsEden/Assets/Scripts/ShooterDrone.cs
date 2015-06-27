using UnityEngine;
using System.Collections;

public class ShooterDrone : MonoBehaviour {

	public GameObject balaPrefab;

	public caracteristicaDrone datos;
		
	public float disparaCada;
	float contadorDisparo = 0f;

	void goToBox(){
		if (datos.box != null)
			transform.position = Vector2.MoveTowards (this.transform.position, datos.box.transform.position, 500*Time.deltaTime);
	}

	public void SetBox(GameObject box){
		if(datos.box != null)
			datos.box.GetComponent<BoxScript> ().taken = false;
		datos.box = box;
		box.GetComponent<BoxScript>().taken = true;
		box.GetComponent<BoxScript> ().SetDrone (this.gameObject);
	}

	public GameObject GetBox(){
		return(datos.box);
	}

	// Update is called once per frame
	void Update () 
	{	
		if(!datos.pausado)
		{
			goToBox();
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
			datos.box.GetComponent<BoxScript>().taken= false;
			Destroy(this.gameObject);
		}
	}
	
	void Disparo(){
		Instantiate(balaPrefab, this.gameObject.transform.position, Quaternion.identity);
	}
}
