using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact key whilst looking at an IInteractive
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{
	[SerializeField]
	private DetectLookedAtInteractive detectLookedAtInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive.LookedAtInteractive != null)
		 {
			Debug.Log("Player pressed the button.");
			detectLookedAtInteractive.LookedAtInteractive.InteractWith();
		 }
    }
}
