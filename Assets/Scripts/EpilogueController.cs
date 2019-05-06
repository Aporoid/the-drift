using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is used to narrate the final scene.
/// </summary>
public class EpilogueController : MonoBehaviour
{
	#region serializedfields
	[Tooltip("Subtitles text object used in this sequence.")]
	[SerializeField]
	private Text endingSubtitles;

	[Tooltip("The image of the folder on the end screen. Serialized to be turned on and off during the cutscene.")]
	[SerializeField]
	private Image folder;

	[Tooltip("The slow-scrolling credits text object. Used to disable at the end of the game.")]
	[SerializeField]
	private GameObject credits;

	[Tooltip("The final text object the player will see after finishing the game.")]
	[SerializeField]
	private Text thankyouText;
	#endregion

	private int lineCount;

	private void Start()
	{
		thankyouText.enabled = false;
		Narration();
	}

	private void Narration()
	{
		if (lineCount == 0)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "Richard Dahl never returned to the force, and the Smiler case remains incomplete.";
		}
		if (lineCount == 1)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "If he was killed by Smiler is unknown, as after several searches of the city, Wasburn remains empty.";
		}
		if (lineCount == 2)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "We fear that Smiler is still out there, and the last of their leads went down with Dahl.";
		}
		if (lineCount == 3)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "For now we just need to hope they resurface again in the future.";
		}
		if (lineCount == 4)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "Our condolences to the Dahl family go out from us today...";
		}
		if (lineCount == 5)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "Logging out, we just got a new lead that the mayor of Wasburn has just been found after being missing for 4 years.";
		}
		if(lineCount == 6)
		{
			StartCoroutine(WaitDuration());
			endingSubtitles.text = "";
			credits.SetActive(false);
			folder.enabled = false;
			thankyouText.enabled = true;
		}
		if(lineCount == 7)
		{
			Application.Quit();
		}
	}

	IEnumerator WaitDuration()
	{
		yield return new WaitForSeconds(6);
		lineCount++;
		Narration();
	}

}
