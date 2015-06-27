using UnityEngine;
using System.Collections;

public class MinaDrone : MonoBehaviour {
	
	public GameObject boxPosition;
	public caracteristicaDrone datos;
	public GameObject explosion;
	
	void Update()
	{
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
		boxPosition.GetComponent<BoxScript>().taken= false;
		Destroy(this.gameObject);
	}
}
