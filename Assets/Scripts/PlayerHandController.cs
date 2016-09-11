using UnityEngine;
using System.Collections;

public class PlayerHandController : MonoBehaviour {
	public GameObject WinZone;
	public GameStateController stateController;
	public Animation doorAnim;
	private bool keyPickedUp = true;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Key" && !keyPickedUp)
		{
			keyPickedUp = true;
			other.transform.SetParent(transform);
			other.transform.localPosition = new Vector3(.02f, -0.05f, -0.04f);
			other.transform.localEulerAngles = new Vector3(180, 0, 90);
			stateController.TriggerKeyPickupEvent();
            other.GetComponent<KeyPosController>().setKeypickedUp(true);
		}

		if (other.tag == "Lock" && keyPickedUp)
		{
			other.transform.parent.gameObject.SetActive(false);
			WinZone.SetActive(true);
			doorAnim.Play();
		}
	}
}