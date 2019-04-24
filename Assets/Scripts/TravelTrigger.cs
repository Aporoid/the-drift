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
		travelText.text = "Press T to enter City Hall";
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact2"))
        {
            travelText.text = "";
            Debug.Log("The player pressed interact");
            SceneManager.LoadScene(3);
        }
    }

	private void OnTriggerExit(Collider other)
	{
		travelText.text = "";
	}
}
