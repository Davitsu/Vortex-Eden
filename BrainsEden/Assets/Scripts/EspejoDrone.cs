using UnityEngine;
using System.Collections;

public class EspejoDrone : MonoBehaviour {

	public GameObject boxPosition;
	public caracteristicaDrone datos;
	
	void Update () {
		//control vida
		if (!datos.pausado) {

			goToBox();

			if (datos.vida <= 0f) {
				boxPosition.GetComponent<BoxScript> ().taken = false;
				Destroy (this.gameObject);
			}
		}
	}

	void goToBox(){
		if (datos.box != null)
			transform.position = Vector2.MoveTowards (this.transform.position, datos.box.transform.position, 300*Time.deltaTime);
	}
	
	public void SetBox(GameObject box){
		if(datos.box != null)
			datos.box.GetComponent<BoxScript> ().taken = false;
		datos.box = box;
		box.GetComponent<BoxScript>().taken = true;
		box.GetComponent<BoxScript> ().SetDrone (this.gameObject);
		Debug.Log ("caja " + box.GetComponent<BoxScript> ().id);
	}
}
