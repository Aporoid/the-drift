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

    private InventoryObject invObject;

    private void Update()
	{
		CheckFlashlight();
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

	private void ShowNewItems(InventoryObject inventoryObject)
	{
		displayTextPickups.text = $"{inventoryObject.objectName} added to Evidence.";
		StartCoroutine("ResetText");
	}

	private IEnumerator ResetText()
	{
		yield return new WaitForSeconds(3);
		displayTextPickups.text = "";
	}

	private void OnEnable()
	{
		InventoryObject.itemWasPickedUp += ShowNewItems;
	}

	private void OnDisable()
	{
		InventoryObject.itemWasPickedUp -= ShowNewItems;
	}
}
