using UnityEngine;
using System.Collections;

public class PlayerHeadController : MonoBehaviour {

	public AudioController audioController;
	public GameStateController gameStateController;

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<GroundSoundController>())
		{
			audioController.currFloorType = other.GetComponent<GroundSoundController>().floorType;
		}

		if(other.tag == "Win")
		{
			gameStateController.TriggerWinGameEvent();
		}
		if (other.GetComponent<WitchController>() != null)
		{
			gameStateController.TriggerDeathEvent();
		}
	}

	void OnTriggerExit(Collider other)
	{
		audioController.currFloorType = AudioController.currentFloorType.Wood;
	}
}
