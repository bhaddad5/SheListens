using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private float playerHeadNoiseSpeedCutoff = 0.003f;
	private float candleNoiseSpeedCutoff = 0.005f;
	private float detectableMovementStepDist = 0.2f;
	public Transform candle;
	public WitchController Witch;
    public GameObject feet;

	private float totalPlayerNoise;
	private float prevTotalPlayerNoise = 0;
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
                AudioTriggers.SetSwitch("Floor", "Wood", this.gameObject);
                break;
            case currentFloorType.Carpet:
                AudioTriggers.SetSwitch("Floor", "Carpet", this.gameObject);
                break;
            case currentFloorType.Glass:
                AudioTriggers.SetSwitch("Floor", "Glass", this.gameObject);
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
				Debug.Log("making player head sound from speed: " + headMoveDist);
				AudioTriggers.PostEvent("Play_Footstep", this.gameObject);
                AudioTriggers.PostEvent("Play_Creaks", this.gameObject);
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
			//Debug.Log("making candle sound from speed: " + candleMoveDist);
			totalPlayerNoise += candleMoveDist;
		}
		prevCandlePos = candle.position;

		Witch.updateNoiseLevel(totalPlayerNoise);

		float witchDistance = Vector3.Magnitude(transform.position - Witch.transform.position);
		if (totalPlayerNoise == 0)
		{
			//Debug.Log("play witch idle sound at distance: " + witchDistance);
		}
		else if(prevTotalPlayerNoise == 0)
		{
			//Debug.Log("Play sound that the witch just saw me!");
		}
		else
		{
			//Debug.Log("Play witch attack at distance: " + witchDistance);
		}

		prevTotalPlayerNoise = totalPlayerNoise;
	}

	public void PlayKeyPickupSound()
	{
		//Debug.Log("play key pickup sound (glass shatter)");
	}
}
