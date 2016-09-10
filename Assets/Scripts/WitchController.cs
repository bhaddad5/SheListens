using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {

	private float maxWitchDistanceFromPlayer = 3.0f;
	private float moveAwayFromPlayerSpeed = -0.003f;
	private float moveTowardsPlayerSpeedModifier = 1f;
	private float minWitchDirectionTime = 6.0f;
	private float maxWitchDirectionTime = 10.0f;
	private float minWitchArcSpeed = 0.002f;
	private float maxWitchArcSpeed = 0.007f;
	private float fixedWitchHeight = 0.6f;

	private float currentNoiseLevel = 0f;
	private Vector3 currentWitchPos;
	private float lastChangedDirTime = 0f;
	private float currentWitchArcTime = 0f;
	private float currentWitchArcSpeed = 0f;
	private float currentWitchArcDir = 1.0f;

	// Update is called once per frame
	void Update () {


		currentWitchPos = UpdateWitchNoiseMovement();

		updateWitchPosition();

		UpdateWitchRotationAroundPlayer();
	}

	private Vector3 UpdateWitchNoiseMovement()
	{
		Vector3 witchNoiseMocement = new Vector3();

		if (currentNoiseLevel == 0)
		{
			if (Vector3.Magnitude(transform.position - Camera.main.transform.position) < maxWitchDistanceFromPlayer)
			{
				witchNoiseMocement = Vector3.MoveTowards(transform.position, Camera.main.transform.position, moveAwayFromPlayerSpeed);
			}
			else
			{
				witchNoiseMocement = Vector3.MoveTowards(transform.position, Camera.main.transform.position, -moveAwayFromPlayerSpeed);
			}
		}
		else
		{
			witchNoiseMocement = Vector3.MoveTowards(transform.position, Camera.main.transform.position, currentNoiseLevel * moveTowardsPlayerSpeedModifier);
		}

		return witchNoiseMocement;
	}

	private void UpdateWitchRotationAroundPlayer()
	{
		if(Time.time - currentWitchArcTime > lastChangedDirTime)
		{
			lastChangedDirTime = Time.time;
			currentWitchArcTime = Random.Range(minWitchDirectionTime, maxWitchDirectionTime);
			currentWitchArcDir = currentWitchArcDir * -1;

			currentWitchArcSpeed = Random.Range(minWitchArcSpeed, maxWitchArcSpeed) * currentWitchArcDir;
		}

		transform.RotateAround(Camera.main.transform.position, Vector3.up, currentWitchArcSpeed * 40f);
	}

	private void updateWitchPosition()
	{
		currentWitchPos.y = fixedWitchHeight;
		transform.position = currentWitchPos;
	}

	public void updateNoiseLevel(float playerNoise)
	{
		currentNoiseLevel = playerNoise;
	}
}
