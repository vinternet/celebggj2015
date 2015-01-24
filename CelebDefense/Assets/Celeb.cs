using UnityEngine;
using System.Collections;

public class Celeb : MonoBehaviour {

	public Vector2 endLocation;
	public float walkSpeed;

	// Use this for initialization
	void Start () {
		endLocation = new Vector2(7.3f, 0f);

		walkSpeed = 1f;
		walkSpeed ++;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
