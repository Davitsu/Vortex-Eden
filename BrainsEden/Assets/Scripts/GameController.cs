using UnityEngine;
using System.Collections;
using UnityEngine.UI;		//para el label

public class GameController : MonoBehaviour {

	public int energia;
	public int energiaMax;
	public Text labelEnergia;
	
	public float vida;
	public float vidaMax;
	public Text labelVida;
	
	public int puntuacion= 0;
	public Text labelPuntuacion;
	
	void Start()
	{
		vida= vidaMax;
	}
	
	void Update()
	{
		//actualizacion de energia
		labelEnergia.text= energia.ToString();
		labelPuntuacion.text= puntuacion.ToString();
		labelVida.text= vida.ToString();
	}

	public void addEnergy(int energy){
		if (energy > 0.0f) {
			energia+=energy;
			if (energia > energiaMax) {
				energia=energiaMax;
			}
		}
	}
	
	public void addPuntuacion(int punt)
	{
		puntuacion+= punt;
	}
	
	public void addHealth(float hp)
	{
		if(hp > 0f){
			vida+= hp;
			if(vida > vidaMax)
			{
				vida= vidaMax;
			}
		}
	}
	
	public void reduceHealth(float hp)
	{
		if(hp > 0f){
			vida-= hp;
			if(vida <= 0f)
			{
				//ESTADO PARTIDA FIN
			}
		}
	}
	
}
