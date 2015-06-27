using UnityEngine;
using System.Collections;

public class EspejoDrone : MonoBehaviour {

	public GameObject boxPosition;
	public caracteristicaDrone datos;
	
	void Update () {
		//control vida
		if(datos.vida <= 0f)
		{
			boxPosition.GetComponent<BoxScript>().taken= false;
			Destroy(this.gameObject);
		}
	}
}
