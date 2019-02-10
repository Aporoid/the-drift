using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
	public Text triggerText;
	public Light triggerLight;
	public GameObject Flashlight;

	private void OnTriggerEnter(Collider other)
	{
		triggerText.text = "Press E to interact";
		triggerLight.enabled = true;
		CheckCollection();
	}

	private void OnTriggerExit(Collider other)
	{
		triggerText.text = "";
		triggerLight.enabled = false;
	}

	private void CheckCollection()
	{
		if (Input.GetButtonDown("Interact"))
		{
			Flashlight.SetActive(false);
		}
	}

}
