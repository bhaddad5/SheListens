using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {

	private float maxWitchDistance = 3.0f;
	private float moveAwayFromPlayerSpeed = -0.003f;
	private float moveTowardsPlayerSpeedModifier = 0.1f;

	private float currentNoiseLevel = 0;

	// Update is called once per frame
	void Update () {
		if(currentNoiseLevel == 0)
		{
			if(Vector3.Magnitude(transform.position - Camera.main.transform.position) < maxWitchDistance)
			{
				transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, moveAwayFromPlayerSpeed);
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, -moveAwayFromPlayerSpeed);
			}
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, currentNoiseLevel * moveTowardsPlayerSpeedModifier);
		}
	}

	public void updateNoiseLevel(float playerNoise)
	{
		currentNoiseLevel = playerNoise;
	}
}
