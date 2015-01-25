using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;


[XmlRoot("CelebStatements")]
public class CelebStatements
{
	[XmlArray("Topics")]
	[XmlArrayItem("Topic")]
	public List<Topic> Topics = new List<Topic>();


	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(CelebStatements));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static CelebStatements Load(string path)
	{
		var serializer = new XmlSerializer(typeof(CelebStatements));
		TextAsset ta = Resources.Load (path) as TextAsset;

		/*using(var reader = new System.IO.StringReader(ta.text))
		{
			return serializer.Deserialize(reader) as CelebStatements;
		}*/

		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as CelebStatements;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static CelebStatements LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(CelebStatements));
		return serializer.Deserialize(new StringReader(text)) as CelebStatements;
	}
}