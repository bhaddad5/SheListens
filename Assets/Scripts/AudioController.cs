using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private float playerHeadNoiseSpeedCutoff = 0.003f;
	private float candleNoiseSpeedCutoff = 0.005f;
	public Transform candle;
	public WitchController Witch;

	private float totalPlayerNoise;
	private Vector3 prevCandlePos;
	private Transform playerHead;
	private Vector3 prevPlayerPos;
	

	public enum currentFloorType
	{
		Wood,
		Glass,
		Carpet
	}
	public currentFloorType currFloorType = currentFloorType.Wood;

	// Use this for initialization
	void Start () {
		playerHead = Camera.main.transform;
		prevPlayerPos = playerHead.position;
		prevCandlePos = candle.position;
	}

	// Update is called once per frame
	void Update()
	{
		totalPlayerNoise = 0;

        switch(currFloorType)
        {
            case currentFloorType.Wood:
                AkSoundEngine.SetSwitch("Floor", "Wood", this.gameObject);
                break;
            case currentFloorType.Carpet:
                AkSoundEngine.SetSwitch("Floor", "Carpet", this.gameObject);
                break;
            case currentFloorType.Glass:
                AkSoundEngine.SetSwitch("Floor", "Glass", this.gameObject);
                break;
            default:
                break;
        }

            float headMoveDist = Vector3.Magnitude(playerHead.position - prevPlayerPos);
		if (headMoveDist >= playerHeadNoiseSpeedCutoff)
		{
			Debug.Log("Playing head sound/volume for speed: " + headMoveDist + ", on " + currFloorType);
            AkSoundEngine.PostEvent("Play_Footstep", this.gameObject);
			totalPlayerNoise += headMoveDist;
		}
		prevPlayerPos = playerHead.position;

		float candleMoveDist = Vector3.Magnitude(candle.position - prevCandlePos);
		if (candleMoveDist >= candleNoiseSpeedCutoff)
		{
			Debug.Log("Playing candle sound/volume for speed: " + candleMoveDist);
			totalPlayerNoise += candleMoveDist;
		}
		prevCandlePos = candle.position;

		Witch.updateNoiseLevel(totalPlayerNoise);
	}
}
