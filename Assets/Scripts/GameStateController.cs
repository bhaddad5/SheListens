﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour {

	public GameObject splashCanvas;
	public GameObject blackImage;
	public GameObject endImage;
	public GameObject keyPickupSceneUpdatePrefab;
	public AudioController audioController;
	public GameObject currentWindow, brokenWindow, shatteredGlass; 

	public GameObject[] objsToDestroyOnSpashscreen;

	public void TriggerKeyPickupEvent()
	{
		Instantiate(keyPickupSceneUpdatePrefab);
		audioController.PlayKeyPickupSound();
		currentWindow.SetActive (false);
		brokenWindow.SetActive (true); 
		shatteredGlass.SetActive (true); 
    }

    public void TriggerWinGameEvent()
	{
		blackImage.SetActive(true);

		playTitleScreen();
	}

	public void TriggerDeathEvent()
	{
		blackImage.SetActive(true);

		playTitleScreen();
	}

	private void playTitleScreen()
	{
		foreach (GameObject obj in objsToDestroyOnSpashscreen)
		{
			obj.SetActive(false);
		}

		splashCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
		splashCanvas.transform.LookAt(Camera.main.transform);

		StartCoroutine(tempdelay());
	}

	IEnumerator tempdelay()
	{
		yield return new WaitForSeconds(3f);
		endImage.SetActive(true);
		blackImage.SetActive(false);
		StartCoroutine(resetGame());
	}

	IEnumerator resetGame()
	{
		yield return new WaitForSeconds(6f);
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainRoom");
	}
}
