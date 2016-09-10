using UnityEngine;
using System.Collections;

public class CandleController : MonoBehaviour {

	public Light candle;
	private float candleBurnoutTime = 200f;

	private float startingIntensity;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		startingIntensity = candle.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		//goes from 0 to 1;
		float intensityScaler = (Time.time - startTime) / candleBurnoutTime;

		candle.intensity = startingIntensity - (intensityScaler * startingIntensity);
	}
}
