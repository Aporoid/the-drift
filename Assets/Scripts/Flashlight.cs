using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light myLight;

	private AudioSource audio;
	public AudioClip flashlightClick;

	private void Start()
	{
		myLight.enabled = false;
		audio = GetComponent<AudioSource>();
	}

	private void Update()
    {
		CheckIfLight();
    }

	private void CheckIfLight()
	{
		if (Input.GetKeyUp(KeyCode.F) && InventoryObject.hasFlashlight == true)
		{
			audio.PlayOneShot(flashlightClick, 1);
			myLight.enabled = !myLight.enabled;
		}
	}
}
