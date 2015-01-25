using UnityEngine;
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

	// Use this for initialization
	void Start ()
	{
				for (int i=0; i<spawnCount; i++) {
						Instantiate (crowdPerson, new Vector3 (Random.Range (spawnLeftX, spawnRightX), Random.Range (spawnBottomY, spawnTopY)), Quaternion.identity);
				}

		statementManager = new CelebStatementManager ();

		}

	// Update is called once per frame
	void Update ()
	{
		statementManager.setNextStatementQuality ();
		//GameObject.Find ("TweetBox").text = statementManager.getUpdatedTweet (Time.deltaTime);
		//print (statementManager.getUpdatedTweet (Time.deltaTime));
	}
}
