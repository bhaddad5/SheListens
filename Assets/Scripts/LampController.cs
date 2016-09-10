using UnityEngine;
using System.Collections;

public class LampController : MonoBehaviour {

	public Light lamp;
	private float lampFlickerIntervalDefault = 7.0f;
	private float lamoFlickerIntervalRange = 4.0f;
	private float flickerRandomRange = 1.0f;
	private float flickerOnTime = 20.0f;

	private float startingLampIntensity;
	private float lastLampFlicker = -10f;
	private float nextLampFlickerTime;
	private float flickerTimeout;
	private float currIntensity;

	void Start()
	{
		startingLampIntensity = lamp.intensity;
		nextLampFlickerTime = Random.Range(lampFlickerIntervalDefault - flickerRandomRange, lampFlickerIntervalDefault + flickerRandomRange);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - nextLampFlickerTime > lastLampFlicker)
		{
			currIntensity = Random.Range(startingLampIntensity - flickerRandomRange, startingLampIntensity + flickerRandomRange);
			lamp.intensity = currIntensity;
			lastLampFlicker = Time.time;
			nextLampFlickerTime = Random.Range(lampFlickerIntervalDefault - flickerRandomRange, lampFlickerIntervalDefault + flickerRandomRange);
			flickerTimeout = flickerOnTime;
		}
		else if(flickerTimeout > 0)
		{
			flickerTimeout--;
			lamp.intensity = currIntensity - (flickerTimeout / flickerOnTime)*currIntensity;
		}
		else
		{
			lamp.intensity = 0f;
		}
	}
}
