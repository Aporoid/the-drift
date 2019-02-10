using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
	public Text triggerText;
	public Light triggerLight;
	public GameObject FlashlightObject;

	private void Update()
	{
		CheckCollection();
	}

	private void OnTriggerEnter(Collider other)
	{
		triggerText.text = "Press E to interact";
		triggerLight.enabled = true;
	}

	private void OnTriggerExit(Collider other)
	{
		triggerText.text = "";
		triggerLight.enabled = false;
	}

	private void CheckCollection()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			FlashlightObject.SetActive(false);
			triggerLight.enabled = false;
			triggerText.text = "";
		}
	}

}
