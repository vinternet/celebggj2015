using UnityEngine;
using System.Collections;

public class CharacterMovementUtils : MonoBehaviour
{
	public static float getZPositionGivenYPosition(float yPosition)
	{
		Debug.Log ((.1f) * (-11f + yPosition));
		return (.1f) * (-11f + yPosition);
	}

	void  Update ()
	{
		this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y,getZPositionGivenYPosition(this.transform.position.y));
	}
}
