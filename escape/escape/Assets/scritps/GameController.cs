using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	
	PlayerMovent playerMovent;
	public GameObject winText, loseText, hardLandText;
	

	void Start()
	{
		playerMovent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovent>();
		
	}

	void LateUpdate()
	{
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			
			
			SceneManager.LoadScene(0);
		}
	}

	public void WinCondition(bool hardLand)
	{
		if (!hardLand)
		{
			winText.SetActive(true);
		}
		if (hardLand)
		{
			hardLandText.SetActive(true);
		}
		StartCoroutine("WinCoroutine");
	}
	public void LoseCondition()
	{
		loseText.SetActive(true);
		playerMovent.canMove = false;
		playerMovent.detectCollision = false;
		playerMovent.canMove = false;
		
	}

	IEnumerator WinCoroutine()
	{
		
		playerMovent.canMove = false;
		playerMovent.detectCollision = false;
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(1);
	}
	
}

internal class PlayerController
{
}