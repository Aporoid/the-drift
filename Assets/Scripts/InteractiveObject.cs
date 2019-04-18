using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script attached to interactive objects, in order to play a SFX and become interactable.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
	[Tooltip ("What you see when you interact with it in the game world")]
	[SerializeField]
	protected string displayText = nameof(InteractiveObject);

	public virtual string DisplayText => displayText;
	protected AudioSource audioSource;

	protected virtual void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public virtual void InteractWith()
	{
		try
		{
			audioSource.Play();
		}
		catch (System.Exception)
		{
			throw new System.Exception("Missing audiosource component: interactiveObject requires an Audiosource component.");
		}
		Debug.Log($"Player just interacted with {gameObject.name}");
	}
}
