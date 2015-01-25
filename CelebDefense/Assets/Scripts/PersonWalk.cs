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


		statements = CelebStatements.Load(Path.Combine(Application.dataPath, "CelebStatements.xml"));
		for(int i = 0; i< 3; i++){
			print(statements.Topics[i].getRandomTweet("Germans"));
		}
		neutralTopic = statements.Topics[0];
		print (neutralTopic.getRandomTweet ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//deice what my three topics are. 
	//get twweets and speehes for aeach of them once
	//pull randomly fro THOSE lists durnig runtime. 

	public Topic neutralTopic; 



}
