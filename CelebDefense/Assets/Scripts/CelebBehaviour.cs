using UnityEngine;
using System.Collections;

public class CelebBehaviour : MonoBehaviour {

	public Transform endGoal;
	public float walkSpeed = 1f;

	private bool reachedGoal = false;
	public bool ReachedGoal
	{
		get {return reachedGoal;}
		set {reachedGoal = value;}
	}

	// Use this for initialization
	void Start ()
	{
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
	void Update ()
	{
		if (reachedGoal == false)
		{
			Vector2 target = new Vector2(endGoal.position.x, endGoal.position.y);
			//Vector2 target = new Vector2(endGoal.position.x, endGoal.position.y);
			Vector2 movementDirection = (target - this.rigidbody2D.position);
			movementDirection.Normalize();
			//Vector3 threeDimensionalDirection = new Vector3(movementDirection.x, movementDirection.y, CelebrityProtection.CharacterMovementUtils.getZPositionGivenYPosition(target.y - this.rigidbody2D.position.y)); 
//			threeDimensionalDirection.Normalize();
			this.rigidbody2D.velocity = walkSpeed * movementDirection;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.name=="CelebrityEndGoal")
		{
			reachedGoal = true;
			Application.LoadLevel("win");
		}
	}
}
