using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to keep players in a set area until they find the next clue.
/// </summary>
public class ClueBoundaryController : MonoBehaviour
{
	#region serializedfields
	[Tooltip("The pop-up text that shows up when the player approaches a boundary")]
	[SerializeField]
	private Text blockerText;

	[Tooltip("The invisible wall around the church and overlook area.")]
	[SerializeField]
	private GameObject churchBlocker;

	[Tooltip("The invisible wall around the park and greenhouse area.")]
	[SerializeField]
	private GameObject parkBlocker;

	[Tooltip("The invisible wall around the graveyard area.")]
	[SerializeField]
	private GameObject graveBlocker;

	[Tooltip("The invisible wall around the barnyard area.")]
	[SerializeField]
	private GameObject barnBlocker;

	[Tooltip("The collider box for detecting the church boundary.")]
	[SerializeField]
	private Collider churchCollider;

	[Tooltip("The collider box for detecting the park boundary.")]
	[SerializeField]
	private Collider parkCollider;

	[Tooltip("The collider box for detecting the graveyard boundary.")]
	[SerializeField]
	private Collider graveyardCollider;

	[Tooltip("The collider box for detecting the barnyard boundary.")]
	[SerializeField]
	private Collider barnCollider;

	[SerializeField]
	private GameObject CityHallHint;
	#endregion

	private void Start()
	{
		churchCollider.enabled = true;
		parkCollider.enabled = true;
		graveyardCollider.enabled = true;
		barnCollider.enabled = true;
		CityHallHint.SetActive(false);
	}

	private void Update()
	{
		CheckColliderSetup();
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("The player entered the trigger");
		CheckBoundaryParameters();
	}

	private void OnTriggerExit(Collider other)
	{
		blockerText.text = "";
		Debug.Log("The player left the trigger");
	}

	private void CheckBoundaryParameters() // method used to decide which boundaries should and shouldn't be enabled. 
	{
		if(InventoryObject.clueNumber == 1)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
		else if (InventoryObject.clueNumber == 2)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
		else if (InventoryObject.clueNumber == 3)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
		else if (InventoryObject.clueNumber == 4)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
		else if (InventoryObject.clueNumber == 5)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
	}

	private void CheckColliderSetup()
	{
		if (InventoryObject.clueNumber == 2)
		{
			churchBlocker.SetActive(false);
			churchCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 3)
		{
			parkBlocker.SetActive(false);
			parkCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 4)
		{
			graveBlocker.SetActive(false);
			graveyardCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 5)
		{
			barnBlocker.SetActive(false);
			barnCollider.enabled = false;
			CityHallHint.SetActive(true);
		}
	}
}
