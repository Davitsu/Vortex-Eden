using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase button
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	//botones
	public Button botonPlaca;
	public Image botImgPlaca;
	public Button botonBotiquin;
	public Image botImgBotiq;
	public Button botonEspejo;
	public Image botImgEspejo;
	public Button botonMina;
	public Image botImgMina;
	public Button botonShooter;
	public Image botImgShooter;
	
	//visual
	public GameObject cruz;
	public GridScript grid;
	
	//enemigos
	public GameObject ShooterDronePrefab;
	
	private int objSeleccionado;
	private Image miniaturaDrag;
	
	//gestos
	Vector2 posIni;
	//bool swipeIn= false;

	
	void Awake(){
		Input.multiTouchEnabled = false;
	}

	// Use this for initialization
	void Start () {
		objSeleccionado= -1;
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
					grid.DisableBoxes();
					objSeleccionado= -1;
					BorrarSeleccion();
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
		else
		{
			cruz.SetActive(false);
		}
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
			if (type == 0) //placa
			{
				GameObject nuevoEnemigo= (GameObject)Instantiate(ShooterDronePrefab, box.transform.position, box.transform.rotation);
				nuevoEnemigo.GetComponent<ShooterDrone>().boxPosition= box;
			} 
			else if (type == 1)	//botiquin
			{
				
			}
			else if (type == 2) //espejo
			{
				
			}
			else if (type == 3) //mina
			{
				
			}
			else if (type == 4) //cañon
			{
				
			}
			box.GetComponent<BoxScript>().taken= true;
		}
	}

	void BorrarSeleccion()
	{
		GameObject[]imagenes= GameObject.FindGameObjectsWithTag("ImagBotonActiv");
		
		foreach(GameObject image in imagenes){
			image.gameObject.SetActive(false);
		}
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
		
		if(objSeleccionado!= -1)
		{
			if(objSeleccionado== 0)	//placa
			{
				botImgPlaca.gameObject.SetActive(true);
			}
			else if (objSeleccionado== 1)	//botiquin
			{
				botImgBotiq.gameObject.SetActive(true);
			}
			else if (objSeleccionado== 2)	//espejo
			{
				botImgEspejo.gameObject.SetActive(true);
			}
			else if (objSeleccionado== 3)	//mina
			{
				botImgMina.gameObject.SetActive(true);
			}
			else if (objSeleccionado== 4)	//cañon
			{
				botImgShooter.gameObject.SetActive(true);
			}	
		}
		else{
			BorrarSeleccion();
		}
		Debug.Log (objSeleccionado);
	}
	#endregion
}
