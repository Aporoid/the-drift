using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to update parts of the HUD canvas, unrelated to the inventory menu.
/// </summary>
public class HUDUpdater : MonoBehaviour
{
	[SerializeField]
	private Image flashlightIndicator;

	public Text displayTextPickups;

	private void Update()
	{
		CheckFlashlight();
		ShowNewItems();
	}

	private void CheckFlashlight()
	{
		if(InventoryObject.hasFlashlight == true)
		{
			flashlightIndicator.enabled = true;
		}
		else if (InventoryObject.hasFlashlight == false)
		{
			flashlightIndicator.enabled = false;
		}
	}

	private void ShowNewItems()
	{
		if(InventoryObject.itemPickedUp == true)
		{
			displayTextPickups.text = "Item added to Evidence.";
			StartCoroutine("ResetText");
		}
	}

	private IEnumerator ResetText()
	{
		yield return new WaitForSeconds(3);
		displayTextPickups.text = "";
		InventoryObject.itemPickedUp = false;
	}
}
