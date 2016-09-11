using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour {
    public LampController lamp;

	private float maxWitchDistanceFromPlayer = 2.8f;
	private float moveAwayFromPlayerSpeed = -0.003f;
	private float moveTowardsPlayerSpeedModifier = 0.8f;
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

	// Update is called once per frame
	void Update () {
		currentWitchPos = UpdateWitchNoiseMovement();

		updateWitchPosition();

		UpdateWitchRotationAroundPlayer();
	}

	private Vector3 UpdateWitchNoiseMovement()
	{
		Vector3 witchNoiseMovement = new Vector3();

		if (currentNoiseLevel == 0)
		{
            witchNoiseMovement = transform.position;
		}
		else
		{
			witchNoiseMovement = Vector3.MoveTowards(transform.position, Camera.main.transform.position, currentNoiseLevel * moveTowardsPlayerSpeedModifier);
			transform.LookAt(Camera.main.transform.position);
		}

		return witchNoiseMovement;
	}

	private void UpdateWitchRotationAroundPlayer()
	{
		if(Time.time - currentWitchArcTime > lastChangedDirTime)
		{
			ChangeWitchArcDirection();
		}

		transform.RotateAround(Camera.main.transform.position, Vector3.up, currentWitchArcSpeed * 10f);
	}

	private void ChangeWitchArcDirection()
	{
		lastChangedDirTime = Time.time;
		currentWitchArcTime = Random.Range(minWitchDirectionTime, maxWitchDirectionTime);
		currentWitchArcDir = currentWitchArcDir * -1;

		currentWitchArcSpeed = Random.Range(minWitchArcSpeed, maxWitchArcSpeed) * currentWitchArcDir;
	}

	public void resetWitchPosition()
	{
		transform.position = Camera.main.transform.position + new Vector3(0f, 0f, maxWitchDistanceFromPlayer);
		transform.RotateAround(Camera.main.transform.position, Vector3.up, Random.Range(0, 360f));
		transform.LookAt(Camera.main.transform);
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
