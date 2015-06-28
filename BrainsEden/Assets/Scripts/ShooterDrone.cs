using UnityEngine;
using System.Collections;

public class ShooterDrone : MonoBehaviour {

	public GameObject balaPrefab;

	public caracteristicaDrone datos;
		
	public float disparaCada;
	float contadorDisparo = 0f;

	void goToBox(){
		if (datos.box != null)
			transform.position = Vector2.MoveTowards (this.transform.position, datos.box.transform.position, 300*Time.deltaTime);
	}

	public void SetBox(GameObject box){
		if (datos.box != null) {
			if(this.gameObject == datos.box.GetComponent<BoxScript>().dron.gameObject){
				datos.box.GetComponent<BoxScript>().dron = null;
				datos.box.GetComponent<BoxScript> ().taken = false;
			}
		}
		datos.box = box;
		box.GetComponent<BoxScript>().taken = true;
		box.GetComponent<BoxScript> ().SetDrone (this.gameObject);
		Debug.Log ("caja " + box.GetComponent<BoxScript> ().id);
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
		Instantiate(balaPrefab, new Vector3(transform.position.x+12, transform.position.y-2, transform.position.z), Quaternion.identity);
	}

	void OnDestroy(){
		datos.box.GetComponent<BoxScript>().taken= false;
		datos.box.GetComponent<BoxScript> ().dron = null;
	}
}
