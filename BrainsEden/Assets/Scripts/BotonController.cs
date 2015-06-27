using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonController : MonoBehaviour {
	
	public GameController datos;
	
	public int precio;
	public float tRecarga;
	float cuentaAtras;
	
	public Button boton;
	public Image botonImaEncendido;
	
	void update()
	{
		if(!boton.enabled)
		{
			if(cuentaAtras > 0f)
				cuentaAtras-= Time.deltaTime;
			else
			{
				if(datos.energia >= precio)
				{
					boton.enabled= true;
				}
			}
		}	
	}
	
	public void Activacion()
	{
		cuentaAtras= tRecarga;
		boton.enabled= false;
		botonImaEncendido.enabled= false;
	}
	
}
