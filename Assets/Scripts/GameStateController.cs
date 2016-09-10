using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	public GameObject blackImage;
	public GameObject endImage;

	public void TriggerKeyPickupEvent()
	{

	}

	public void TriggerWinGameEvent()
	{
		blackImage.SetActive(true);

		StartCoroutine(playTitleScreen());
	}

	public void TriggerDeathEvent()
	{
		blackImage.SetActive(true);

		StartCoroutine(playTitleScreen());
	}

	IEnumerator playTitleScreen()
	{
		yield return new WaitForSeconds(1f);
		endImage.SetActive(true);
		blackImage.SetActive(false);
		StartCoroutine(resetGame());
	}

	IEnumerator resetGame()
	{
		yield return new WaitForSeconds(3f);
		endImage.SetActive(false);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainRoom");
	}
}
