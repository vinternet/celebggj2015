using UnityEngine;
using System.Collections;

public class CelebBehaviour : MonoBehaviour {

	public Transform endGoal;
	public float walkSpeed = 1f;

	// Use this for initialization
	void Start () {
		if (endGoal == null)
		{
			endGoal = GameObject.Find("CelebrityEndGoal").transform;
			if (endGoal == null)
			{
				endGoal = this.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 target = new Vector2(endGoal.position.x, endGoal.position.y);
		Vector2 movementDirection = (target - this.rigidbody2D.position);
		movementDirection.Normalize();
		this.rigidbody2D.velocity = walkSpeed * movementDirection;
	}
}
