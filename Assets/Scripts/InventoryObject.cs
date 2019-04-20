using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
	[Tooltip("Name of the object as it will appear in the inventory menu UI")]
	[SerializeField]
	private string objectName = nameof(InventoryObject);

	[Tooltip("Text that will be display in the menu when the player selects this object.")]
	[TextArea(3, 5)]
	[SerializeField]
	private string description;

	[Tooltip("Icon to display in the menu for this object.")]
	[SerializeField]
	private Sprite icon;

	[Tooltip("Used to indicate if the inventory object is a smiler clue or not.")]
	[SerializeField]
	private bool isClue;

	public Sprite Icon => icon;
	public string ObjectName => objectName;
	public string Description => description;
	public static int clueNumber;

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
		InventoryMenu.Instance.AddItemToMenu(this);
		renderer.enabled = false;
		collider.enabled = false;
		TestClue();
	}

	private void TestClue()
	{
		if(isClue == true)
		{
			clueNumber++;
		}
	}
}
