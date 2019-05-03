using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	/// <summary>
	/// This causes a purposeful delay to simulate a "loading screen".
	/// </summary>
	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(1);
	}

	public void Credits()
	{
		Application.OpenURL("https://docs.google.com/document/d/13gk1uE2NBC20ZVJlLmtLoMnycH66E8xByu3F316JaWA/edit?usp=sharing");
	}
}
