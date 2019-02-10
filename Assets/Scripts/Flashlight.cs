using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

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
		}
		else
		{
			playerLight.SetActive(false);
		}
	}
}
