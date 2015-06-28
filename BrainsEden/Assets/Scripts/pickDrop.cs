using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase button
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	//botones
	public Button botonPlaca;
	public Button botonBotiquin;
	public Button botonEspejo;
	public Button botonMina;
	public Button botonShooter;
	
	//visual
	public GameObject cruz;
	public GridScript grid;
	public GameObject marco;
	
	//drones
	public GameObject ShooterDronePrefab;
	private GameObject SelectedGridDrone;

	private int objSeleccionado;
	private Image miniaturaDrag;
	
	//gestos
	//Vector2 posIni;
	//bool swipeIn= false;

	void Awake(){
		SelectedGridDrone = null;
		Input.multiTouchEnabled = false;
	}

	// Use this for initialization
	void Start () {
		objSeleccionado= -1;
	}

	void Update()
	{
//		if(Input.position.x > Screen.width * 0.1f

		if(Input.touchCount > 0)
		{
			if(Input.touches[0].position.x > Screen.width * 0.1f && objSeleccionado!= -1)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
				{
					cruz.gameObject.transform.position= Input.touches[0].position;
					cruz.SetActive(true);
					GameObject box = ComprobarBox(Input.touches[0].position);
					box.GetComponent<SpriteRenderer>().color.a = 1.0f;
				}
				else if(Input.touches[0].phase == TouchPhase.Ended)
				{
					GameObject box = ComprobarBox(Input.touches[0].position);
					if(box != null)
					{
						crearObjecto(objSeleccionado, box);
					}
					cruz.SetActive(false);
					grid.DisableBoxes();
					objSeleccionado= -1;
					marco.SetActive(false);
				}
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
			}
		}
		else if(Input.GetMouseButtonUp(0)){
			Vector3 position = Input.mousePosition;

			//si pulsas en caja y tenias dron de tienda
			if(position.x > Screen.width * 0.1f && (objSeleccionado != -1 && objSeleccionado != -2)){	//si tocas el grid con dron comprado

				GameObject box = ComprobarBox(position);
				if(box != null)
				{
					crearObjecto(objSeleccionado, box);
				}
				//crearObjecto(objSeleccionado, Input.touches[0].position);
				cruz.SetActive(false);
				grid.DisableBoxes();
				objSeleccionado= -1;
				marco.SetActive(false);

				//Debug.Log ("Pulsado con dron de tienda"+objSeleccionado);
			}//si pulsas en caja y no tenias dron
			else if(position.x > Screen.width * 0.1f && objSeleccionado == -1){ //si no tienes dron y coges uno de grid
				GameObject box = ComprobarBox(position);
				if(box != null)
				{
//					crearObjecto(objSeleccionado, box);
					SelectedGridDrone = box.GetComponent<BoxScript>().dron;
					if(SelectedGridDrone != null){
						//Debug.Log ("Has cogido dron del grid");
						objSeleccionado= -2; //si la caja tiene dron pues has cogido un dron del grid
						cruz.SetActive(true);
						grid.EnableFreeBoxes();
					}
				}
				//Debug.Log ("Pulsado sin dron cogido"+objSeleccionado);
			}
			else if(position.x > Screen.width * 0.1f && objSeleccionado == -2){ //si pulsas caja de grid con un dron cogido de grid
				GameObject box = ComprobarBox(position);
				if(box != null){
					if(box.GetComponent<BoxScript>().dron != null){
						GameObject boxDelDronAMover = SelectedGridDrone.GetComponent<caracteristicaDrone>().box;
						GameObject dronAReemplazar = box.GetComponent<BoxScript>().dron;
						Debug.Log ("Dron a reemplazar, caja "+dronAReemplazar.GetComponent<caracteristicaDrone>().box.GetComponent<BoxScript>().id+" se cambia a");
						dronAReemplazar.SendMessage("SetBox", boxDelDronAMover);
					}
					Debug.Log ("Dron que reemplaza, caja "+SelectedGridDrone.GetComponent<caracteristicaDrone>().box.GetComponent<BoxScript>().id+" se cambia a");
					SelectedGridDrone.SendMessage("SetBox", box);
					objSeleccionado = -1;
					SelectedGridDrone = null;
					
					grid.DisableBoxes();
					cruz.SetActive(false);

				}
				Debug.Log ("Pulsado con dron cogido de grid: "+objSeleccionado);
			}
		}
		else
		{
			cruz.SetActive(false);
//			Debug.Log ("Pulsado en otra situacion"+objSeleccionado);
		}
	}
	

	#region funciones privadas
	GameObject ComprobarBox(Vector3 touchPosition)
	{
		Vector3 point = Camera.main.ScreenToWorldPoint (touchPosition);
		//		Debug.Log(ray);

		Collider2D hit = Physics2D.OverlapPoint(new Vector2(point.x, point.y));

		if (hit != null) {
			if (hit.gameObject.tag.Equals ("Box")) {
				return(hit.gameObject);
			}
			else if (hit.gameObject.tag.Equals ("Drone")){
				return(hit.gameObject.GetComponent<caracteristicaDrone> ().box);
			}
		} 
		return(null);
	}
	
	void crearObjecto(int type, GameObject box)
	{
		if(!box.GetComponent<BoxScript>().taken)
		{
			GameObject nuevoEnemigo = null;
			if (type == 0) //placa
			{
				nuevoEnemigo= (GameObject)Instantiate(ShooterDronePrefab, box.transform.position, box.transform.rotation);
				botonPlaca.GetComponent<BotonController>().Activacion();
				
				nuevoEnemigo.SendMessage("SetBox", box);
			} 
			else if (type == 1)	//botiquin
			{
				//aqui instanciar drone (como arriba)
				botonBotiquin.GetComponent<BotonController>().Activacion();
			}
			else if (type == 2) //espejo
			{
				//aqui instanciar drone (como arriba)
				botonEspejo.GetComponent<BotonController>().Activacion();
			}
			else if (type == 3) //mina
			{
				//aqui instanciar drone (como arriba)
				botonMina.GetComponent<BotonController>().Activacion();
			}
			else if (type == 4) //cañon
			{
				//aqui instanciar drone (como arriba)
				botonShooter.GetComponent<BotonController>().Activacion();
			}

		}
	}
	#endregion

	#region funciones publicas
	public void BotonApretado(Button boton)
	{	
		if(boton.interactable){
			int objNum= boton.GetComponent<BotonController>().numBoton;
			
			//seleccion boton
			if (objSeleccionado == objNum) {
				objSeleccionado = -1;
				grid.DisableBoxes ();
			} 
			else
			{
				objSeleccionado= objNum;
				grid.EnableFreeBoxes();
			}
			
			if(objSeleccionado!= -1)
			{
				if(objSeleccionado== 0)	//placa
				{
					marco.transform.position= botonPlaca.transform.position;
				}
				else if (objSeleccionado== 1)	//botiquin
				{
					marco.transform.position= botonBotiquin.transform.position;
				}
				else if (objSeleccionado== 2)	//espejo
				{
					marco.transform.position= botonEspejo.transform.position;
				}
				else if (objSeleccionado== 3)	//mina
				{
					marco.transform.position= botonMina.transform.position;
				}
				else if (objSeleccionado== 4)	//cañon
				{
					marco.transform.position= botonShooter.transform.position;	
				}	
				marco.SetActive(true);
			}
			else{
				marco.SetActive(false);
			}
		}
	}
	#endregion
}
