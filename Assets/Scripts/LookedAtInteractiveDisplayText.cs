using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Used to change the UI text when something is interacted with
/// The text should disappear when not looking at a thing
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
	private IInteractive lookedAtInteractive;
	private Text displayText;

	private void Awake()
	{
		displayText = GetComponent<Text>();
		UpdateDisplayText();
	}

	private void UpdateDisplayText()
	{
		if(lookedAtInteractive != null)
			displayText.text = lookedAtInteractive.DisplayText;
		else
		{
			displayText.text = string.Empty;
		}
	}

	/// <summary>
	/// Event handler for DetectLookedAtInteractive
	/// </summary>
	/// <param name="newLookedAtInteractive"></param>
	private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
	{
		lookedAtInteractive = newLookedAtInteractive;
		UpdateDisplayText();
	}

	#region Event Suscription/unsubscription
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
