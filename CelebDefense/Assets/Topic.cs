using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Topic
{ 
	[XmlAttribute("name")]
	public string Name;
	
	[XmlArray("Tweets")]
	[XmlArrayItem("Tweet")]
	public List<string> Tweets = new List<string>();

	[XmlArray("Speeches")]
	[XmlArrayItem("Speech")]
	public List<string> Speeches = new List<string>();


	public string getRandomTweet(string topic){
		if (topic != Name)
						return "nope";
		return Tweets [0];
	}

	public string getRandomTweet()	{
		return Tweets[Random.Range (0, Tweets.Count - 1)];

	}


}