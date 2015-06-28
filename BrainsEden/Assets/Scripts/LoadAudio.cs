using UnityEngine;
using System.Collections;

public class LoadAudio : MonoBehaviour {

	//public static LoadAudio instance;
	
	//SONIDOS
	public AudioSource click_play;
	AudioClip click_play_clip;
	public AudioSource click_button;
	AudioClip click_button_clip;
	public AudioSource click_back;
	AudioClip click_back_clip;
	
	// Use this for initialization
	void Start () {
		click_play_clip = (AudioClip)Resources.Load ("Sounds/click_start.wav");
		click_play.clip = click_play_clip;
		click_button_clip = (AudioClip)Resources.Load ("Sounds/click_play.wav");
		click_button.clip = click_button_clip;
		click_back_clip = (AudioClip)Resources.Load ("Sounds/click_back.wav");
		click_back.clip = click_back_clip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
