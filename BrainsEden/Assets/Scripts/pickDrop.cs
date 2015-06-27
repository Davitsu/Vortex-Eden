﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase button
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	//botones
	public Button botonCubo;
	public Button botonEsfera;
	
	//visual
	public GameObject iconSelec;
	public GameObject cruz;
	public GridScript grid;
	
	//enemigos
	public GameObject ShooterDronePrefab;
	
	private int objSeleccionado;
	private Image miniaturaDrag;
	
	//gestos
	Vector2 posIni;
	//bool swipeIn= false;
	
	//DEVELOPEMENT_BUILD
	public Text inputPos;
	public Text	textoSelec;
	public Text labelGestos;
	
	void Awake(){
		Input.multiTouchEnabled = false;
	}

	// Use this for initialization
	void Start () {
		objSeleccionado= -1;
		#if DEVELOPMENT_BUILD
		inputPos.gameObject.SetActive(true);
		textoSelec.gameObject.SetActive(true);
		labelGestos.gameObject.SetActive(true);
		#endif
	}

	void Update()
	{
		if(Input.touchCount > 0)
		{
			if(Input.touches[0].position.x > Screen.width * 0.1f && objSeleccionado!= -1)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
				{
					cruz.gameObject.transform.position= Input.touches[0].position;
					cruz.SetActive(true);
				}
				else if(Input.touches[0].phase == TouchPhase.Ended)
				{
					GameObject box = ComprobarBox(Input.touches[0].position);
					if(box != null)
					{						
						crearObjecto(objSeleccionado, box);
					}
					//crearObjecto(objSeleccionado, Input.touches[0].position);
					cruz.SetActive(false);
					iconSelec.SetActive(false);
					grid.DisableBoxes();
					objSeleccionado= -1;
				}
				#if DEVELOPMENT_BUILD
				inputPos.text= Input.touches[0].position.x.ToString() + " , " + Input.touches[0].position.y.ToString();
				#endif
			}
			//gestual
			/*else if(objSeleccionado== -1)
			{
				if(Input.touches[0].phase == TouchPhase.Began)
				{
					posIni= Input.touches[0].position;
				}
				else if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
				{
					Vector2 posFin= Input.touches[0].position;
					
					if(posIni.x > posFin.x && Vector2.Distance(posIni, posFin) >= Screen.width / 5f )
					{
						swipeIn= true;
					}
				}
				else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
				{
					swipeIn= false;
				}
				labelGestos.text= "SWIPE " + swipeIn.ToString();
			}*/
			else
			{
				cruz.SetActive(false);
				#if DEVELOPMENT_BUILD
				inputPos.text= "N/A";
				#endif
			}
		}
		else
		{
			cruz.SetActive(false);
			#if DEVELOPMENT_BUILD
			inputPos.text= "N/A";
			#endif
		}
		#if DEVELOPMENT_BUILD
		if(objSeleccionado == -1)
		{
			textoSelec.text="Seleccion: N/A";
		}
		else
		{
			textoSelec.text="Seleccion: " + objSeleccionado;
		}
		#endif
	}
	

	#region funciones privadas
	GameObject ComprobarBox(Vector3 touchPosition)
	{
		Ray ray = Camera.main.ScreenPointToRay(touchPosition);
		Debug.Log(ray);
		
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider != null)
			{
				if(hit.collider.gameObject.tag.Equals("Box"))
				{
					Debug.Log (hit.collider.gameObject.GetComponent<BoxScript>().id);
					return(hit.collider.gameObject);
				}
			}
		}
		return(null);
	}
	
	void crearObjecto(int type, GameObject box)
	{	
		if(!box.GetComponent<BoxScript>().taken)
		{
			if (type == 0) 
			{
				GameObject nuevoEnemigo= (GameObject)Instantiate(ShooterDronePrefab, box.transform.position, box.transform.rotation);
				nuevoEnemigo.GetComponent<ShooterDrone>().boxPosition= box;
			} 
			else if (type == 1) 
			{
				
			}
			box.GetComponent<BoxScript>().taken= true;
		}
	}

	void OnclickIzq()
	{
		Debug.Log(Time.realtimeSinceStartup + "-> PANTALLA:" + Input.mousePosition);
		Debug.Log(Time.realtimeSinceStartup + "-> MUNDO REAL:" + Camera.main.ScreenToWorldPoint(Input.mousePosition) + "\n==============");
		ComprobarBox(Input.mousePosition);
	}
	#endregion

	#region funciones publicas
	public void BotonApretado(int objNum)
	{
		//seleccion boton
		if(objSeleccionado == objNum)
		{
			objSeleccionado= -1	;
			grid.DisableBoxes();
		}
		else
		{
			objSeleccionado= objNum;
			grid.EnableFreeBoxes();
		}
		
		//icono de seleccion
		if(objSeleccionado!= -1)
		{
			if(objSeleccionado== 0)
			{
				iconSelec.transform.position= botonCubo.gameObject.transform.position;
			}
			else if (objSeleccionado== 1)
			{
				iconSelec.transform.position= botonEsfera.gameObject.transform.position;
			}	
			iconSelec.SetActive(true);
		}
		else
		{
			iconSelec.SetActive(false);
		}
	}
	#endregion
}
