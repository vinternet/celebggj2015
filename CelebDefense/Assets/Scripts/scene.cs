using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Shush")){
			Application.LoadLevel ("vin_scene_1");
		}
	}
}
