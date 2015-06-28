using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonController : MonoBehaviour {
	public GameController datos;
	public int numBoton	;
	public int precio;
	public float tRecarga;
	float cuentaAtras= 0f;
	public Button boton;

	void Update()
	{
		if(cuentaAtras > 0f)
			cuentaAtras-= Time.deltaTime;
		else
		{
			if(datos.energia >= precio && cuentaAtras <= 0f)
			{
				boton.interactable= true;
			}
			else
			{
				boton.interactable= false;
			}
		}
	}
	
	public void Activacion()
	{
		datos.energia-= precio;
		cuentaAtras= tRecarga;
		boton.interactable= false;
	}
	
}
