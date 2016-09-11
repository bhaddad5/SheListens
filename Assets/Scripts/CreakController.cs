using UnityEngine;
using System.Collections;

public class CreakController : MonoBehaviour {

	private float lerpTime = 2.0f;
	private float maxDist = 1.0f;

	private float lastLerpTime = -2.0f;
	private Vector3 targetPos = Vector3.zero;
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = Camera.main.transform.position;

		if (Time.time - lerpTime > lastLerpTime)
		{
			targetPos = new Vector3(randVal(playerPos.x), 0, randVal(playerPos.z));
			lastLerpTime = Time.time;
		}

		float t = (Time.time - lastLerpTime) / lerpTime;
		transform.position = Vector3.Lerp(transform.position, targetPos, t);
	}

	private float randVal(float val)
	{
		return Random.Range(val - maxDist, val + maxDist);
	}
}
