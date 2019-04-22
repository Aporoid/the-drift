using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TravelTrigger : MonoBehaviour
{
	public Text travelText;

	private void OnTriggerEnter(Collider other)
	{
		travelText.text = "Press E to enter City Hall";
		Travel();
	}

	private void OnTriggerExit(Collider other)
	{
		travelText.text = "";
	}

	private void Travel()
	{
		if (Input.GetButtonDown("Interact"))
		{
			travelText.text = "";
			SceneManager.LoadScene(3);
		}
	}
}
