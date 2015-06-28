using UnityEngine;
using System.Collections;
using UnityEngine.UI;		//para el label

public class GameController : MonoBehaviour {

	public int energia;
	public Text labelEnergia;
	
	void Update()
	{
		//actualizacion de energia
		labelEnergia.text= energia.ToString();
	}
}
