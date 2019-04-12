using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
	[Tooltip("Specifies which image icon will be associated with this object")]
	[SerializeField]
	private Image iconImage;

	public static event Action<InventoryObject> InventoryMenuItemSelected;
	private InventoryObject associatedInventoryObject;

	public InventoryObject AssociatedInventoryObject
	{
		get
		{
			return associatedInventoryObject;
		}
		set
		{
			associatedInventoryObject = value;
			iconImage.sprite = associatedInventoryObject.Icon;
		}
	}

	/// <summary>
	/// This will be plugged into the toggle's "nValueChanged" property in the edtiror, called whenever the toggle is clicked.
	/// </summary>
	public void InventoryMenuItemWasToggled(bool isOn)
	{
		// we only want to do this when the toggle has been selected.
		if (isOn)
		{
			InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
		}
		Debug.Log($"Toggled: {isOn}");
	}

	private void Awake()
	{
		Toggle toggle = GetComponent<Toggle>();
		ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
		toggle.group = toggleGroup;
	}
}
