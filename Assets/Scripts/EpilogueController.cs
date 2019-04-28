using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpilogueController : MonoBehaviour
{
	[SerializeField]
	private Text prologueSubtitles;
	[SerializeField]
	private Image folder;
	[SerializeField]
	private GameObject credits;
	[SerializeField]
	private Text thankyouText;


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
			prologueSubtitles.text = "Richard Dahl never returned to the force, and the Smiler case remains incomplete.";
		}
		if (lineCount == 1)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "If he was killed by Smiler is unknown, as after several searches of the city, Wasburn remains empty.";
		}
		if (lineCount == 2)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "We fear that Smiler is still out there, and the last of their leads went down with Dahl.";
		}
		if (lineCount == 3)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "For now we just need to hope they resurface again in the future.";
		}
		if (lineCount == 4)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "Our condolensences to the Dahl family go out to us today.";
		}
		if (lineCount == 5)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "Logging out, we just got a new lead that the mayor of Wasburn has just been found after being missing for 4 years.";
		}
		if(lineCount == 6)
		{
			StartCoroutine(WaitDuration());
			prologueSubtitles.text = "";
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
