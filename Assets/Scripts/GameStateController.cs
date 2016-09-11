using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	public GameObject splashCanvas;
	public GameObject blackImage;
	public GameObject endImage;
	public GameObject keyPickupSceneUpdatePrefab;
	public AudioController audioController;
	private Animator windowAnim; 

	public GameObject[] objsToDestroyOnSpashscreen;

	public void TriggerKeyPickupEvent()
	{
		windowAnim = GameObject.Find("WindowGlass").GetComponent<Animator> ();
		windowAnim.SetBool ("windowBreak", true); 
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

		splashCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		splashCanvas.transform.LookAt(Camera.main.transform);

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
