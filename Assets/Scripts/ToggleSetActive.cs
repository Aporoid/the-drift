using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact key whilst looking at an IInteractive
/// </summary>
public class ToggleSetActive : InteractiveObject
{
	[Tooltip ("The gameobject to toggle.")]
	[SerializeField]
	private GameObject objectToToggle;

	[Tooltip("Can the player interact with this more than once?")]
	[SerializeField]
	private bool isReusable = true;

	private bool hasBeenUsed = false;
	/// <summary>
	/// Toggles the activeSelf value for the ObjectToToggle when the player interacts with this object.
	/// </summary>
	public override void InteractWith()
	{
		if (isReusable || !hasBeenUsed)
		{
			base.InteractWith();
			objectToToggle.SetActive(!objectToToggle.activeSelf);
			hasBeenUsed = true;
			if (!isReusable) displayText = string.Empty;
		}
	}
}
