using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private float playerHeadNoiseSpeedCutoff = 0.003f;
	private float candleNoiseSpeedCutoff = 0.005f;
	private float detectableMovementStepDist = 0.2f;
	public Transform candle;
	public WitchController Witch;

	private float totalPlayerNoise;
	private Vector3 prevCandlePos;
	private Transform playerHead;
	private Vector3 prevPlayerPos;
	private bool trackindDetectableMovement = false;
	private Vector3 startHeadDetectableMovementPos;

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
			if (!trackindDetectableMovement)
			{
				trackindDetectableMovement = true;
				startHeadDetectableMovementPos = playerHead.position;
			}

			if (Vector3.Magnitude(playerHead.position - startHeadDetectableMovementPos) > detectableMovementStepDist)
			{
				float wwiseSpeed = Utility.SuperLerp(0, 1, 0, 0.05f, headMoveDist);
				Debug.Log("Playing head sound/volume for speed: " + wwiseSpeed + ", on " + currFloorType);

				AkSoundEngine.PostEvent("Play_Footstep", this.gameObject);
				totalPlayerNoise += headMoveDist;
			}
		}
		else if(trackindDetectableMovement)
		{
			trackindDetectableMovement = false;
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
