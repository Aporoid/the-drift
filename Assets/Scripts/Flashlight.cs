using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	public AudioSource audioSource;
	public GameObject playerLight;

	private void Update()
	{
		LightOn();
	}

	void LightOn()
	{
		if (Input.GetKey(KeyCode.F))
		{
			playerLight.SetActive(true);
			audioSource.Play();
		}
		else
		{
			playerLight.SetActive(false);
		}
	}
}
