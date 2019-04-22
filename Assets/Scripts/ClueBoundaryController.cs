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

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("The player entered the trigger");
		CheckBoundaryParameters();
	}

	private void OnTriggerExit(Collider other)
	{
		blockerText.text = "";
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
		}
		else if (InventoryObject.clueNumber == 3)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			parkBlocker.SetActive(false);
		}
		else if (InventoryObject.clueNumber == 4)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			graveBlocker.SetActive(false);
		}
		else if (InventoryObject.clueNumber == 5)
		{
			blockerText.text = "I haven't found the clue in this area yet.";
			barnBlocker.SetActive(false);
		}
	}
}
