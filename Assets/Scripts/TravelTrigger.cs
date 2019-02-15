using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelTrigger : MonoBehaviour
{
	public Text travelText;

	private void OnTriggerEnter(Collider other)
	{
		travelText.text = "Press E to travel";
	}

	private void Travel()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			travelText.text = "";
		}
	}
}
