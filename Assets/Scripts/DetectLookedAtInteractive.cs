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


	public IInteractive LookedAtInteractive
	{
		get { return lookedAtInteractive; }
		private set { lookedAtInteractive = value; }
	}

	private IInteractive lookedAtInteractive;

	private void FixedUpdate()
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

		if(interactive != null)
		{
			lookedAtInteractive = interactive;
		}
	}
}
