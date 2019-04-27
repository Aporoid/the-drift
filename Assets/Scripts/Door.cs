using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
	[Tooltip("Assigning a key here will lock the door. If the player has a key in their inventory, they can open a locked door.")]
	[SerializeField]
	private InventoryObject key;

	[Tooltip("When the key is used, the associated key will be removed from the player's inventory.")]
	[SerializeField]
	private bool consumesKey;

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
	public override string DisplayText
	{
		get
		{
			string toReturn;

			if (isLocked)
				//toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
				toReturn = HasKey ? $"Unlock" : lockedDisplayText;
			else
				toReturn = base.DisplayText;

			return toReturn;
		}
	}

	private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
	private Animator animator;
	private bool isOpen = false;
	private int shouldOpenAnimParameter = Animator.StringToHash("shouldOpen");
	private bool isLocked;

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
		InitializeIsLocked();
	}

	private void InitializeIsLocked()
	{
		if (key != null)
			isLocked = true;
	}

	public override void InteractWith()
	{
		if (!isOpen)
		{
			if (isLocked && !HasKey)
			{
				audioSource.clip = lockedAudioClip;
			}
			else // if its not locked, or if its locked and we have the key
			{
				audioSource.clip = openAudioClip;
				animator.SetBool("shouldOpen", true);
				displayText = string.Empty;
				isOpen = true;
				UnlockDoor();
			}
			base.InteractWith(); //this plays a SFX from InteractiveObject.cs
		}
	}

	private void UnlockDoor()
	{
		isLocked = false;
		if (key != null && consumesKey)
		{
			PlayerInventory.InventoryObjects.Remove(key);
		}
	}
}
