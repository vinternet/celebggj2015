using UnityEngine;
using System.Collections;

/*
 * Taken from here:
 * http://indiedevspot.azurewebsites.net/2014/04/25/build-a-2d-top-down-game-zero-to-published-part-1/
 */

//require Character Script to be attached to this object.
[RequireComponent(typeof(CharacterScript))]
public class CharacterInput : MonoBehaviour {
	//private reference to the character script for making calls to the public api.
	private CharacterScript character;
	
	//reference to the camera
	private Camera mainCamera;
	
	private Vector2 heading;
	private CircleCollider2D checker;
	private GameObject celeb;
	private CelebStatementManager sm;

	public float shushCooldown = 0.5f;
	public float inputCooldown = 0.01f;
	private float shushTimer = 0f;
	private float inputTimer = 0f;
	
	/// <summary>
	/// Use this function for initialization of just this component.
	/// </summary>
	private void Awake () 
	{
		//nothing special to initialize here.
		heading = Vector2.zero;
	}
	
	/// <summary>
	/// Use this function for initialization that depends on other components being created.
	/// </summary>
	private void Start()
	{
		//we require a built up version of the character script.
		this.character = this.GetComponent<CharacterScript>();
		
		this.mainCamera = Camera.main;
		checker = GameObject.Find ("Checker").GetComponent<CircleCollider2D>();
		celeb = GameObject.Find ("Celebrity");
		sm = GameObject.Find ("GameSystem").GetComponent<CelebStatementManager>();
	}
	
	/// <summary>
	/// use this function to process updates as fast as the game can process them.
	/// </summary>
	void Update()
	{
		//check for touches
		/*if (Input.touchCount > 0)
		{
			//what was the position?
			Vector2 touchPosition = Input.GetTouch(0).position;
			Vector3 touchWorldPosition = this.mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 15));
			//where is our character currently?
			Vector3 characterPosition = character.gameObject.transform.position;
			//vector math says point to get to - current position = heading.
			this.heading = new Vector2(touchWorldPosition.x - characterPosition.x, touchWorldPosition.y - characterPosition.y);
			//make sure we don't surpass 1.
			this.heading.Normalize();
		}*/
		float shushButton = Input.GetAxis ("Shush");
		inputTimer += Time.deltaTime;
		shushTimer += Time.deltaTime;
		if(inputTimer > inputCooldown)
		{
			if(shushButton > 0)
			{
				inputTimer = 0f;

				if(checker.bounds.Intersects(celeb.collider2D.bounds))
				{
					
					//Cancel current tweet.
					sm.cancelCurrentTweet();
					sm.cancelCurrentSpeech();
					
					//If tweet was bad, nothing happens.
					//If tweet was good, lose Smoothie.
					//Trigger a cooldown.
					//Split this "if" to cover tweet and speech separately.
				}
			}
		}

	}
	
	/// <summary>
	/// use this function to process updates that should be synchronized 
	/// with the physics engine.  Good for continuous input functions for movement.
	/// </summary>
	void FixedUpdate()
	{
		//get the x factor of movement.
		float xMovement = Input.GetAxis("Horizontal");
		//get the y factor of movement.
		float yMovement = Input.GetAxis("Vertical");
		
		Vector2 movement = new Vector2(xMovement, yMovement);
		
		if (movement.magnitude >= 0)
		{
			this.heading = movement.normalized;
		}

		//use our character script reference to make a call into its public api
		//to move the character by our input factor.
		character.Move(heading);
	}
}