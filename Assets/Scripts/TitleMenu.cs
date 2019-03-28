using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used to load appropriate responses to menu interaction.
/// </summary>
public class TitleMenu : MonoBehaviour
{
	[SerializeField]
	private string gameSceneName;

	public void LoadGameScene()
	{
		SceneManager.LoadScene(gameSceneName);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
