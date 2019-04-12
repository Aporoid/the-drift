using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
	[Tooltip("Specifies which image icon will be associated with this object")]
	[SerializeField]
	private Image iconImage;

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
}
