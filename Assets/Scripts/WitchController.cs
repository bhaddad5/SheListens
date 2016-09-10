using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {

	private float maxWitchDistanceFromPlayer = 1.4f;
	private float moveAwayFromPlayerSpeed = -0.003f;
	private float moveTowardsPlayerSpeedModifier = 1f;
	private float minWitchDirectionTime = 12.0f;
	private float maxWitchDirectionTime = 24.0f;
	private float minWitchArcSpeed = 0.002f;
	private float maxWitchArcSpeed = 0.007f;
	private float fixedWitchHeight = 1.2f;

	private float currentNoiseLevel = 0f;
	private Vector3 currentWitchPos;
	private float lastChangedDirTime = 0f;
	private float currentWitchArcTime = 0f;
	private float currentWitchArcSpeed = 0f;
	private float currentWitchArcDir = 1.0f;
	private bool hittingWall = false;

	// Update is called once per frame
	void Update () {


		currentWitchPos = UpdateWitchNoiseMovement();

		updateWitchPosition();

		UpdateWitchRotationAroundPlayer();
	}

	private Vector3 UpdateWitchNoiseMovement()
	{
		Vector3 witchNoiseMocement = new Vector3();

		if (currentNoiseLevel == 0 && !hittingWall)
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
			ChangeWitchArcDirection();
		}

		transform.RotateAround(Camera.main.transform.position, Vector3.up, currentWitchArcSpeed * 40f);
	}

	private void ChangeWitchArcDirection()
	{
		lastChangedDirTime = Time.time;
		currentWitchArcTime = Random.Range(minWitchDirectionTime, maxWitchDirectionTime);
		currentWitchArcDir = currentWitchArcDir * -1;

		currentWitchArcSpeed = Random.Range(minWitchArcSpeed, maxWitchArcSpeed) * currentWitchArcDir;
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

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Wall")
		{
			ChangeWitchArcDirection();
			hittingWall = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Wall")
		{
			hittingWall = false;
		}
	}
}
