using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private float playerHeadNoiseSpeedCutoff = 0.002f;
	private float candleNoiseSpeedCutoff = 0.004f;
	private float detectableMovementStepDist = 0.1f;
	private float angryDistCutoff = 2.0f;
	public Transform candle;
	public WitchController Witch;
    public GameObject feet;
	public GameObject creakObject;
    public GameObject window;
    public GameObject lampLight;
    public GameObject lampParent;

	private float totalPlayerNoise;
	private float prevTotalPlayerNoise = 0;
	private Vector3 prevCandlePos;
	private Transform playerHead;
	private Vector3 prevPlayerPos;
	private bool trackindDetectableMovement = false;
	private Vector3 startHeadDetectableMovementPos;
	private Animator witchAngryAnim; 
	private Animator witchIdleAnim;
	private bool lampOn;

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
        AudioTriggers.PostEvent("Play_BaseLayer", this.gameObject);
        AudioTriggers.PostEvent("Play_MusicEnemy", Witch.gameObject);
        AudioTriggers.PostEvent("Play_Witch_Hunting", Witch.gameObject);
        AudioTriggers.PostEvent("Play_Witch_Idle", Witch.gameObject);


        AudioTriggers.PostEvent("Play_Lightbulb_Buzz", lampLight);
        AudioTriggers.PostEvent("Play_Lightbulb_Metal", lampLight);
        AudioTriggers.PostEvent("Play_Lightbulb_Zap", lampLight);
    }

	// Update is called once per frame
	void Update()
	{
		totalPlayerNoise = 0;

		switch (currFloorType)
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
				//Debug.Log("making player head sound from speed: " + headMoveDist);
				AudioTriggers.PostEvent("Play_Footstep", this.gameObject);
                AudioTriggers.PostEvent("Play_Creaks", creakObject);
				totalPlayerNoise += headMoveDist;
			}
		}
		else if (trackindDetectableMovement)
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

        if (!lampOn)
        {
            if (Witch == null)
				return;

			Witch.updateNoiseLevel(totalPlayerNoise);

			float witchDistance = Vector3.Magnitude(transform.position - Witch.transform.position);
			if (totalPlayerNoise == 0)
			{
				witchIdleAnim = GameObject.Find ("WitchModel").GetComponent<Animator> ();
				witchIdleAnim.SetBool ("witchAngry", false); 
				AudioTriggers.SetState("Witch", "Idle");
				AudioTriggers.SetRTPC("witchDist", witchDistance);
				//Debug.Log("play witch idle sound at distance: " + witchDistance);
			}
			else if (witchDistance >= angryDistCutoff)
			{
				AudioTriggers.SetState("Witch", "Hunting");
				AudioTriggers.SetRTPC("witchDist", witchDistance);
				//Debug.Log("Play witch moving towards you at distance: " + witchDistance);
			}
			else
			{
				witchAngryAnim = GameObject.Find ("WitchModel").GetComponent<Animator> (); 
				witchAngryAnim.SetBool ("witchAngry", true);
				AudioTriggers.SetState("Witch", "Attack");
				AudioTriggers.PostEvent("Play_Witch_Scream", Witch.gameObject);
				AudioTriggers.SetRTPC("witchDist", witchDistance);
				Debug.Log("Play witch angry at distance: " + witchDistance);
			}

            //AudioTriggers.PostEvent("Play_ZapOff", lampLight);
        }
		else
		{
            //AudioTriggers.PostEvent("Play_ZapOn", lampLight);
            
        }

		prevTotalPlayerNoise = totalPlayerNoise;
	}

	public void KeyMove(GameObject key)
	{
		//AudioTriggers.PostEvent("Play_KeyMove", key);
	}

	public void GameOver()
	{
		AudioTriggers.SetState("Witch", "GameOver");
	}

    public void PlayKeyPickupSound()
	{
        AudioTriggers.PostEvent("Play_KeyPickUp", candle.gameObject);
        AudioTriggers.PostEvent("Play_GlassSmash", window);
        //Debug.Log("play key pickup sound (glass shatter)");
    }

	public void SetLampState(bool on)
	{
		lampOn = on;
        if(on)
        {
            AudioTriggers.PostEvent("Play_ZapOn", lampLight);
        }
        else
        {
            AudioTriggers.PostEvent("Play_ZapOff", lampLight);
        }
	}
}
