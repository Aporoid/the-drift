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
        if (Input.GetKeyUp(KeyCode.F))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
