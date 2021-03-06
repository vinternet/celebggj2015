﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour {

	public Rigidbody2D crowdPerson;
	public float spawnLeftX = -10f;
	public float spawnRightX = 10f;
	public float spawnTopY = 5f;
	public float spawnBottomY = -5f;
	public int spawnCount = 100;
	public CelebStatementManager statementManager;

	public float levelLeftX = -11f;
	public float levelRightX = 22f;
	public float levelTopY = 5.5f;
	public float levelBottomY = -5.5f;

	private GameObject topWall;
	private GameObject[] backgrounds;

	// Use this for initialization
	void Start ()
	{
//<<<<<<< HEAD
				for (int i=0; i<spawnCount; i++) {
						Instantiate (crowdPerson, new Vector3 (Random.Range (spawnLeftX, spawnRightX), Random.Range (spawnBottomY, spawnTopY)), Quaternion.identity);
				}

		//statementManager = new CelebStatementManager ();

		//}
//======
		for (int i=0; i<spawnCount; i++)
		{
			Instantiate (crowdPerson, new Vector3 (Random.Range (spawnLeftX, spawnRightX), Random.Range (spawnBottomY, spawnTopY)), Quaternion.identity);
			//go.AddComponent<Animation>(CelebWalk);

		}
//>>>>>>> ef520937d8b5ad6dff4f6269f83ea98e5ab42dd4

		//statementManager = new CelebStatementManager ();
		statementManager = gameObject.GetComponent<CelebStatementManager>();

		topWall = GameObject.Find ("LevelTopWall");

		backgrounds = new GameObject[2];
		backgrounds[0] = GameObject.Find ("Background1");
		backgrounds[1] = GameObject.Find ("Background2");

		//topWall.transform.localScale.x = 100;
		topWall.transform.localScale = new Vector2 (100, topWall.transform.localScale.y);
		topWall.transform.position = new Vector2(System.Math.Min (backgrounds[0].transform.position.x, backgrounds[1].transform.position.x),topWall.transform.position.y);
		//topWall.transform.position.x = System.Math.Min (backgrounds[0].transform.position.x, backgrounds[1].transform.position.x);
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		//GameObject.Find ("TweetBox").text = statementManager.getUpdatedTweet (Time.deltaTime);
		//print (statementManager.getUpdatedTweet (Time.deltaTime));

	}
}
