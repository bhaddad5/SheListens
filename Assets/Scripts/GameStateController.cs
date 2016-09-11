using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	public GameObject spashCanvas;
	public GameObject blackImage;
	public GameObject endImage;
	public GameObject keyPickupSceneUpdatePrefab;
	public AudioController audioController;

	public GameObject[] objsToDestroyOnSpashscreen;

	public void TriggerKeyPickupEvent()
	{
		Instantiate(keyPickupSceneUpdatePrefab);
		audioController.PlayKeyPickupSound();
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

		foreach (GameObject obj in objsToDestroyOnSpashscreen)
		{
			Destroy(obj);
		}

		spashCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		spashCanvas.transform.eulerAngles = Camera.main.transform.eulerAngles * -1;
		spashCanvas.transform.eulerAngles = new Vector3(0f, spashCanvas.transform.eulerAngles.y, 0f);
		spashCanvas.transform.Rotate(new Vector3(0, 180f, 0));

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
