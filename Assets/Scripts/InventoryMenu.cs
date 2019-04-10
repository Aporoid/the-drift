using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
	private static InventoryMenu instance;
	private CanvasGroup canvasGroup;

	public static InventoryMenu Instance
	{
		get
		{
			if(instance == null)
			{
				throw new System.Exception("This is currently no InventoryMenu instance, " + "But you're trying to access it! Make sure the InventoryMenu script is applied to a GameObject in the scene");
			}
			return instance;
		}
		private set { instance = value; }
	}

	private bool isVisible => canvasGroup.alpha > 0;

	private void ShowMenu()
	{
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
	}

	private void HideMenu()
	{
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
	}

	private void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown("InventoryShow"))
		{
			if (isVisible)
			{
				HideMenu();
			}
			else
			{
				ShowMenu();
			}
		}
	}

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			throw new System.Exception("An instance of InventoryMenu exists and no more than one can exist at one time.");

		canvasGroup = GetComponent<CanvasGroup>();
		HideMenu();
	}
}
