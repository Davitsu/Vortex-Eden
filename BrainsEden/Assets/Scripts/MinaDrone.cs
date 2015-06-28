using UnityEngine;
using System.Collections;

public class MinaDrone : MonoBehaviour {

	public caracteristicaDrone datos;
	public GameObject explosion;

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


	void Update()
	{
		goToBox();
		//control vida
		if(datos.vida <= 0f)
		{
			Explotar(this.transform.position);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Explotar(this.transform.position);
		}
	}
	
	void Explotar(Vector2 pos)
	{
		Instantiate(explosion, pos, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnDestroy(){
		datos.box.GetComponent<BoxScript>().taken= false;
		datos.box.GetComponent<BoxScript> ().dron = null;
	}
}
