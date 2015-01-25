using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class CelebStatementManager : MonoBehaviour {

	public const float TIME_BETWEEN_LETTERS = 0.03f;
	public const float TIME_BETWEEN_STATEMENTS = 0.5f;
	public const float MAX_TIME_BETWEEN_SCANDALS = 10f;
	public const float MIN_TIME_BETWEEN_SCANDALS = 4f;

	public const int ODDS_OF_BAD = 5; //1 in how many are bad. 

	private bool isNextStatementBad;

	public bool IsCurrentSpeechBad;
	public bool IsCurrentTweetBad;

	public CelebStatements statements;
	public Topic neutralTopic; 

	private Topic badTopic1;
	private Topic badTopic2;
	private Topic badTopic3;

	public string currentTweet;
	public string currentSpeech;

	public float timeSinceLastTweetLetter; 
	public float timeSinceLastSpeechLetter; 

	public int curTweetLetterIndex;
	public int curSpeechLetterIndex; 

	public int tweetState;
	public int speechState;

	public float timeSinceLastScandal;

	Text tweettext;

	//how to create stuff not in the universe
	public CelebStatementManager(){
		Start ();
	}

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

		currentTweet = getGoodTweet ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string getGoodSpeech(){
		return neutralTopic.Speeches [Random.Range (0, neutralTopic.Speeches.Count - 1)];
	}

	public string getGoodTweet(){
		return neutralTopic.Tweets [Random.Range (0, neutralTopic.Tweets.Count - 1)];
	}

	private string getBadSpeech(){
		int i = Random.Range (1, 3);
		if(i==1)					
			return badTopic1.Speeches [Random.Range (0, badTopic1.Speeches.Count - 1)];
		if(i==2)					
			return badTopic2.Speeches [Random.Range (0, badTopic2.Speeches.Count - 1)];
		if(i==3)					
			return badTopic3.Speeches [Random.Range (0, badTopic3.Speeches.Count - 1)];
		return "";
	}

	private string getBadTweet(){
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
		//print ("curTweetLetterIndex:" + curTweetLetterIndex);
		//print ("currentTweet.Length:" + (currentTweet.Length-1));
		//print ("timeSinceLastTweetLetter:" + timeSinceLastTweetLetter);
		if (curTweetLetterIndex == (currentTweet.Length - 1)) {
			if (timeSinceLastTweetLetter >= TIME_BETWEEN_STATEMENTS) {
				timeSinceLastTweetLetter = 0;
				currentTweet = getTweet(); //replace with logic to swith
				curTweetLetterIndex = 0;
			}
		}else if (timeSinceLastTweetLetter >= TIME_BETWEEN_LETTERS) {
				timeSinceLastTweetLetter = 0;
				curTweetLetterIndex++;
		}	
			
		
		return currentTweet.Substring (0, curTweetLetterIndex+1);
	}

	public string getUpdatedSpeech(float elapsedTime){
		timeSinceLastSpeechLetter += elapsedTime;
		if (curSpeechLetterIndex == (currentTweet.Length - 1)) {
			if (timeSinceLastSpeechLetter >= TIME_BETWEEN_STATEMENTS) {
				timeSinceLastSpeechLetter = 0;
				currentSpeech = getSpeech(); //replace with logic to swith
				curSpeechLetterIndex = 0;
			}
		}else if (timeSinceLastSpeechLetter >= TIME_BETWEEN_LETTERS) {
			timeSinceLastSpeechLetter = 0;
			curSpeechLetterIndex++;
		}		
		
		return currentTweet.Substring (0, curTweetLetterIndex+1);
	}

	private string getTweet(){
		if (isNextStatementBad) {
			isNextStatementBad = false;
			IsCurrentTweetBad = true;
			return getBadTweet ();
		} else {
			IsCurrentTweetBad = false;
			return getGoodTweet();
		}
	}

	private string getSpeech(){
		if (isNextStatementBad) {	
			IsCurrentTweetBad = true;
			isNextStatementBad = false;
			return getBadSpeech ();
		} else {
			IsCurrentTweetBad = false;
			return getGoodSpeech();
		}
	}

	public void setNextStatementQuality(){
		int roll = Random.Range (1, ODDS_OF_BAD);
		isNextStatementBad = (roll == 1);
	}


}
