using UnityEngine;
using System.Collections;
using System;

public class HealthBarScript : MonoBehaviour
{
	private float healthBarWidth;
	private GameObject healthBar;
	// Use this for initializationr
	void Start ()
	{
		healthBarWidth = 0;
		healthBar = GameObject.Find ("healthbar");
		updateHealthBarWidth (0.5f, 1f);
	}

	void updateHealthBarWidth(float currentHealth, float maximumHealth)
	{
		float healthPercent = 1 - (currentHealth / maximumHealth);
		float currentX = healthBar.transform.lossyScale.x;
		Debug.Log (currentX);
		Vector3 currentPos = healthBar.transform.position;
		healthBar.transform.localScale = healthBar.transform.localScale - new Vector3(healthPercent, 0, 0);
		currentPos.x = currentX;
		healthBar.transform.position = currentPos;
	}
}