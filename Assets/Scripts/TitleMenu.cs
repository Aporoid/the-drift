using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used to load appropriate responses to menu interaction.
/// </summary>
public class TitleMenu : MonoBehaviour
{
	public void LoadGameScene()
	{
		StartCoroutine("Countdown");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(1);
	}
}
