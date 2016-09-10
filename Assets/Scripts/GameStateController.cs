﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	public GameObject spashCanvas;
	public GameObject blackImage;
	public GameObject endImage;
	public GameObject[] objsToDestroyOnSpashscreen;

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

		foreach (GameObject obj in objsToDestroyOnSpashscreen)
		{
			Destroy(obj);
		}

		spashCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		spashCanvas.transform.eulerAngles = Camera.main.transform.eulerAngles * -1;
		spashCanvas.transform.Rotate(new Vector3(0, 180f, 0));

		endImage.SetActive(true);
		blackImage.SetActive(false);
		StartCoroutine(resetGame());

		Debug.Log("run reset game");
	}

	IEnumerator resetGame()
	{
		Debug.Log("stuff!");

		yield return new WaitForSeconds(3f);
		endImage.SetActive(false);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainRoom");
	}
}
