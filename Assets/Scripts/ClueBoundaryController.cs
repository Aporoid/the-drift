using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to keep players in a set area until they find the next clue.
/// </summary>
public class ClueBoundaryController : MonoBehaviour
{
	public Text blockerText;
	public GameObject churchBlocker;
	public GameObject parkBlocker;
	public GameObject graveBlocker;
	public GameObject barnBlocker;

	public Collider churchCollider;
	public Collider parkCollider;
	public Collider graveyardCollider;
	public Collider barnCollider;

	private void Start()
	{
		churchCollider.enabled = true;
		parkCollider.enabled = true;
		graveyardCollider.enabled = true;
		barnCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("The player entered the trigger");
		CheckBoundaryParameters();
		StartCoroutine("Countdown");
	}

	private void OnTriggerExit(Collider other)
	{
		blockerText.text = "";
		Debug.Log("The player left the trigger");
	}

	private void CheckBoundaryParameters()
	{
		if(InventoryObject.clueNumber == 1)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
		}
		else if (InventoryObject.clueNumber == 2)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			churchBlocker.SetActive(false);
			churchCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 3)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			parkBlocker.SetActive(false);
			parkCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 4)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			graveBlocker.SetActive(false);
			graveyardCollider.enabled = false;
		}
		else if (InventoryObject.clueNumber == 5)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			barnBlocker.SetActive(false);
			barnCollider.enabled = false;
		}
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds(3);
		blockerText.text = "";
	}
}
