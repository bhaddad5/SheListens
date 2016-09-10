using UnityEngine;
using System.Collections;

public class PlayerHandController : MonoBehaviour {

	private bool keyPickedUp = false;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("collided with something!");

		if(other.tag == "Key")
		{
			keyPickedUp = true;
			other.transform.SetParent(transform);
			other.transform.localPosition = new Vector3(0, 0, 0.3f);
			other.transform.localEulerAngles = Vector3.zero;
		}

		if (other.tag == "Lock" && keyPickedUp == true)
		{
			other.transform.parent.gameObject.SetActive(false);
		}
	}
}
