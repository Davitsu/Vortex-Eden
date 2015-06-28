using UnityEngine;
using System.Collections;

public class MirrorDrone : MonoBehaviour {

	public GameObject balaPrefab;

	public caracteristicaDrone datos;

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
	
		}
		
		//control vida
		/*if(datos.vida <= 0f)
		{
			datos.box.GetComponent<BoxScript>().taken= false;
			Destroy(this.gameObject);
		}*/
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name.Contains("LaserBullet")){
			Destroy(other.gameObject);
			Disparo();
		}
		else if (other.gameObject.name.Contains("Melee")){
			SendMessage("Damage",100);
		}
	}
	
	void Disparo(){
		Instantiate(balaPrefab, new Vector3(transform.position.x+12, transform.position.y-2, transform.position.z), Quaternion.identity);
	}

	void OnDestroy(){
		GameObject.Find ("Pick&DropController").SendMessage ("CheckDestroyed", this.gameObject);
		datos.box.GetComponent<BoxScript>().taken= false;
		datos.box.GetComponent<BoxScript> ().dron = null;
	}
}
