using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonController : MonoBehaviour {
	public GameController datos;
	public int numBoton	;
	public int precio;
	public float tRecarga;
	float cuentaAtras;
	public Button boton;

	void Update()
	{
		if(!boton.interactable)
		{
			if(cuentaAtras > 0f)
				cuentaAtras-= Time.deltaTime;
			else
			{
				if(datos.energia >= precio)
				{
					boton.interactable= true;
				}
			}
		}	
	}
	
	public void Activacion()
	{
		cuentaAtras= tRecarga;
		boton.interactable= false;
	}
	
}
