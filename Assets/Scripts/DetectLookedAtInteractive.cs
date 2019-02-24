using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects interactive elements the player is looking at.
/// </summary>

public class DetectLookedAtInteractive : MonoBehaviour
{
	[Tooltip("Starting point of raycast used to detect interactives.")]
	[SerializeField]
	private Transform raycastOrigin;

	[Tooltip("How far from the racast origin we will search for interactive elements")]
	[SerializeField]
	private float maxRange = 5.0f;

	public static event Action<IInteractive> LookedAtInteractiveChanged;

	public IInteractive LookedAtInteractive
	{
		get { return lookedAtInteractive; }
		private set
		{
			bool isInteractiveChanged = value != lookedAtInteractive;
			if (isInteractiveChanged)
			{
				lookedAtInteractive = value;
				LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
			}
		}
	}

	private IInteractive lookedAtInteractive;

	private void FixedUpdate()
	{
		LookedAtInteractive = GetLookedAtInteractive();
	}

	private IInteractive GetLookedAtInteractive()
	{
		Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
		RaycastHit hitInfo;
		bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

		IInteractive interactive = null;

		LookedAtInteractive = interactive;

		if (objectWasDetected)
		{
			interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
			//Debug.Log("Player is looking at " + hitInfo.collider.gameObject.name);
		}

		return interactive;
	}
}
