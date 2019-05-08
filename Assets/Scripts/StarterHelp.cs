using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterHelp : MonoBehaviour
{
	[SerializeField]
	private Text hintText;

	[SerializeField]
	private Collider starterTrigger;

	private void Start()
	{
		starterTrigger.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		hintText.text = "Collect your gear off the table. Don't forget to read the note!";
	}

	private void OnTriggerExit(Collider other)
	{
		StartCoroutine(WaitTime());
		starterTrigger.enabled = false;
	}

	private IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(3);
		hintText.text = "";
	}
}
