using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Celeb : MonoBehaviour {

	public Vector2 endLocation;
	public float walkSpeed;
	public CelebStatements statements;


	// Use this for initialization
	void Start () {
		endLocation = new Vector2(7.3f, 0f);

		walkSpeed = 1f;
		walkSpeed ++;




		//////////////////////////////////////////////////////////
		/// 


		//statements = CelebStatements.Load(Path.Combine(Application.dataPath, "CelebStatements.xml"));
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}





}
