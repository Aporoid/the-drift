using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
	[Tooltip("Check this box to set door's lock status")]
	[SerializeField]
	private bool isLocked;

	[Tooltip("Text that displays when the player looks at a locked door")]
	[SerializeField]
	private string lockedDisplayText = "Locked";

	[Tooltip("This audio clip plays when the door is locked and tried to open.")]
	[SerializeField]
	private AudioClip lockedAudioClip;

	[Tooltip("This audio clip plays when the door is interacted with and unlocked")]
	[SerializeField]
	private AudioClip openAudioClip;

	//If this conidition is true, it will display the door is locked. If false, it will display the default text.
	public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

	private Animator animator;
	private bool isOpen = false;
	private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");

	/// <summary>
	///  Using a constructor here to initialize displayText in the editor
	/// </summary>
	public Door()
	{
		//Changes UI text to be appropriate of door's name
		displayText = nameof(Door);
	}

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	public override void InteractWith()
	{
		if (!isOpen)
		{
			if (!isLocked)
			{
				audioSource.clip = openAudioClip;
				animator.SetBool("shouldOpen", true);
				displayText = string.Empty;
				isOpen = true;
			}
			else // if the door is locked
			{
				audioSource.clip = lockedAudioClip;
			}
			base.InteractWith(); //this plays a SFX from InteractiveObject.cs
		}
	}

}
