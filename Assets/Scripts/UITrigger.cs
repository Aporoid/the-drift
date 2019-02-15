using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
	public Text triggerText;
	public Text objectiveText;
	public Light triggerLight;
	public GameObject FlashlightObject;

	private void Start()
	{
		triggerLight.enabled = false;
	}

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
			objectiveText.text = "Hold F to use the light!";
		}
	}

}
