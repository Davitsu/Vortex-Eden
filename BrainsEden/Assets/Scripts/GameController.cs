using UnityEngine;
using System.Collections;
using UnityEngine.UI;		//para el label

public class GameController : MonoBehaviour {

	public int energia;
	public int energiaMax;
	public Text labelEnergia;
	
	void Update()
	{
		//actualizacion de energia
		labelEnergia.text= energia.ToString();
	}

	public void addEnergy(int energy){
		if (energy > 0.0f) {
			energia+=energy;
			if (energia > energiaMax) {
				energia=energiaMax;
			}
		}
	}
}
