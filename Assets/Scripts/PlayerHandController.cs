using UnityEngine;
using System.Collections;

public class PlayerHandController : MonoBehaviour {
	public GameObject WinZone;
	public GameStateController stateController;
	private bool keyPickedUp = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Key")
		{
			keyPickedUp = true;
			other.transform.SetParent(transform);
			other.transform.localPosition = new Vector3(0, 0, 0.1f);
			other.transform.localEulerAngles = Vector3.zero;
			stateController.TriggerKeyPickupEvent();
		}

		if (other.tag == "Lock" && keyPickedUp == true)
		{
			other.transform.parent.gameObject.SetActive(false);
			WinZone.SetActive(true);
		}
	}
}