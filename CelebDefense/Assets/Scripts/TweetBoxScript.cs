using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TweetBoxScript : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		// i have no idea how to do this

	//	CelebStatementManager sman = GameObject.Find("statementManager").GetComponent<CelebStatementManager> ();
		//text.text = sman.getUpdatedTweet(Time.deltaTime);
		text.text = "hi";
	}
}
