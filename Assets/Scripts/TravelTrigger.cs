using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TravelTrigger : MonoBehaviour
{
	public Text travelText;
	public Canvas loadingScreen;

	private void Start()
	{
		loadingScreen.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		travelText.text = "Press E to enter City Hall";
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact"))
        {
			loadingScreen.enabled = true;
            travelText.text = "";
            Debug.Log("The player pressed interact");
			StartCoroutine(Countdown());
        }
    }

	private void OnTriggerExit(Collider other)
	{
		travelText.text = "";
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(3);
	}
}
