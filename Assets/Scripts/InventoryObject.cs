﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
	[Tooltip("Name of the object as it will appear in the inventory menu UI")]
	[SerializeField]
	private string objectName = nameof(InventoryObject);

	//TODO: Add long description field
	//TODO: Add icon field

	public string ObjectName => objectName;

	private new Renderer renderer;
	private new Collider collider;

	private void Start()
	{
		renderer = GetComponent<Renderer>();
		collider = GetComponent<Collider>();
	}

	public InventoryObject()
	{
		displayText = $"Take {objectName}";
	}

	/// <summary>
	///  When the player interacts with an inventory object we need to:
	///   1. Add the object to the PlayerInventory list
	///   2. Remove object from Game world
	///   Can't Destroy, need to keep gameobject in inventory list. Diisable renderer and collider instead.
	/// </summary>
	public override void InteractWith()
	{
		base.InteractWith();
		PlayerInventory.InventoryObjects.Add(this);
		renderer.enabled = false;
		collider.enabled = false;
	}
}
