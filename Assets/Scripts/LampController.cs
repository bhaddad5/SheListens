﻿using UnityEngine;
using System.Collections;

public class LampController : MonoBehaviour {

	public Light lamp;
	public KeyPosController keyController;
	public WitchController witch;
	private float lampFlickerIntervalDefault = 16.0f;
	private float lamoFlickerIntervalRange = 6.0f;
	private float flickerRandomRange = 1.0f;
	private float flickerOnTime = 120.0f;

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
			witch.gameObject.SetActive(false);
		}
		else if(flickerTimeout > 0)
		{
			flickerTimeout--;
			lamp.intensity = currIntensity - (1-(flickerTimeout / flickerOnTime))*currIntensity;
		}
		else if(flickerTimeout == 0)
		{
			flickerTimeout--;
			lamp.intensity = 0f;
			keyController.RespawnKey();
			witch.gameObject.SetActive(true);
			witch.resetWitchPosition();
		}
	}
}
