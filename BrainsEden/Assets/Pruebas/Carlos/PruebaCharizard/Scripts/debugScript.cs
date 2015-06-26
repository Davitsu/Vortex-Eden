using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class debugScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
		GameObject.Find("developText").GetComponent<Text>().enabled= true;
#endif
		Debug.Log("Texto developer: " + GameObject.Find("developText").GetComponent<Text>().enabled);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
