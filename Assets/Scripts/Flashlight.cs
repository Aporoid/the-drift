using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light myLight;

	private void Start()
	{
		myLight.enabled = false;
	}

	private void Update()
    {
		CheckIfLight();
    }

	private void CheckIfLight()
	{
		if (Input.GetKeyUp(KeyCode.F) && InventoryObject.hasFlashlight == true)
		{
			myLight.enabled = !myLight.enabled;
		}
	}
}
