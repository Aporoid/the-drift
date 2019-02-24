using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact key whilst looking at an IInteractive
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{
	private IInteractive lookedAtInteractive;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
		{
			Debug.Log("Player pressed the button.");
			lookedAtInteractive.InteractWith();
		}
    }

	private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
	{

	}

	#region event sub/unsub
	private void OnEnable()
	{
		DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
	}
	private void OnDisable()
	{
		DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
	}
	#endregion
}
