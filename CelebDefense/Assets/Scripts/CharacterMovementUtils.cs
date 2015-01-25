using UnityEngine;
using System.Collections;

public class CharacterMovementUtils : MonoBehaviour
{
	public float TopY = 6.0f;
	public float BottomY = -6.0f;
	public float FrontZ = -1.0f;
	public float BackZ = 0f;

	public static float getZPositionGivenYPosition(float yPosition)
	{
		Debug.Log ((.1f) * (-11f + yPosition));
		return (.1f) * (-11f + yPosition);

	}

	public float getZfromY(float yPosition)
	{
		//float newYPosition = Mathf.Clamp (yPosition, BottomY, TopY);
		float interval = (yPosition - BottomY) / (TopY - BottomY);

		return interval;
	}

	void  Update ()
	{
//		this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y,getZPositionGivenYPosition(this.transform.position.y));
		this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y,getZfromY(this.transform.position.y));
	}
}
