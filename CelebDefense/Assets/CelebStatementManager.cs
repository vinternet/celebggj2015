using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class CelebStatementManager : MonoBehaviour {

	public const float TIME_BETWEEN_LETTERS = 0.08f;
	public const float TIME_BETWEEN_STATEMENTS = 1.5f;

	public CelebStatements statements;
	public Topic neutralTopic; 

	public Topic badTopic1;
	public Topic badTopic2;
	public Topic badTopic3;

	public string currentTweet;
	public string currentSpeech;

	public float timeSinceLastTweetLetter; 
	public float timeSinceLastSpeechLetter; 

	public int curTweetLetterIndex;
	public int curSpeechLetterIndex; 

	public int tweetState;
	public int speechState;

	public float timeSinceLastScandal;

		// Use this for initialization
	void Start () {
	
		statements = CelebStatements.Load(Path.Combine(Application.dataPath, "CelebStatements.xml"));
		neutralTopic = statements.Topics[0];

		//fine as long as there are at least 3 topics. lol
		badTopic1 = statements.Topics[Random.Range(0, statements.Topics.Count-1)];
		do {
			badTopic2 = statements.Topics[Random.Range(0, statements.Topics.Count-1)];
		} while(badTopic2.Equals(badTopic1));

		do {
			badTopic3 = statements.Topics[Random.Range(0, statements.Topics.Count-1)];
		} while(badTopic3.Equals(badTopic1) || badTopic3.Equals(badTopic2));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getGoodSpeech(){
		return neutralTopic.Speeches [Random.Range (0, neutralTopic.Speeches.Count - 1)];
	}

	public string getGoodTweet(){
		return neutralTopic.Tweets [Random.Range (0, neutralTopic.Tweets.Count - 1)];
	}

	public string getBadSpeech(){
		int i = Random.Range (1, 3);
		if(i==1)					
			return badTopic1.Speeches [Random.Range (0, badTopic1.Speeches.Count - 1)];
		if(i==2)					
			return badTopic2.Speeches [Random.Range (0, badTopic2.Speeches.Count - 1)];
		if(i==3)					
			return badTopic3.Speeches [Random.Range (0, badTopic3.Speeches.Count - 1)];
		return "";
	}

	public string getBadTweet(){
		//lol why didn't i make this an array style 
		int i = Random.Range (1, 3);
		if(i==1)					
			return badTopic1.Tweets [Random.Range (0, badTopic1.Tweets.Count - 1)];
		if(i==2)					
			return badTopic2.Tweets [Random.Range (0, badTopic2.Tweets.Count - 1)];
		if(i==3)					
			return badTopic3.Tweets [Random.Range (0, badTopic3.Tweets.Count - 1)];
		return "";
	}

	public string getUpdatedTweet(float elapsedTime){
		timeSinceLastTweetLetter += elapsedTime;

		//if im at the end of the statement, compare teh tiem to teh wait timer
		if (curTweetLetterIndex == currentTweet.Length - 1) {
			if (timeSinceLastTweetLetter >= TIME_BETWEEN_STATEMENTS) {
				timeSinceLastTweetLetter = 0;
				currentTweet = getGoodTweet(); //replace with logic to swith
				curTweetLetterIndex = 0;
			}else //if im midd statement, update the letter{
				if (timeSinceLastTweetLetter >= TIME_BETWEEN_LETTERS) {
					timeSinceLastTweetLetter = 0;
					curTweetLetterIndex++;
				}	
		}	
		
		return currentTweet.Substring (0, curTweetLetterIndex);
	}


	/**
	 * statements = CelebStatements.Load(Path.Combine(Application.dataPath, "CelebStatements.xml"));
	for(int i = 0; i< 3; i++){
		print(statements.Topics[i].getRandomTweet("Germans"));
	}
	neutralTopic = statements.Topics[0];
	print (neutralTopic.getRandomTweet ());


	//deice what my three topics are. 
	//get twweets and speehes for aeach of them once
	//pull randomly fro THOSE lists durnig runtime. 

	public Topic neutralTopic; 
*/


}
