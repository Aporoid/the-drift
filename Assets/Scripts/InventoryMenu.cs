using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
	private static InventoryMenu instance;
	private CanvasGroup canvasGroup;
	private RigidbodyFirstPersonController rigidbodyFirstPersonController;
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

	public void ExitMenuButtonClicked()
	{
		HideMenu();
	}

	private void ShowMenu()
	{
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		rigidbodyFirstPersonController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	private void HideMenu()
	{
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		rigidbodyFirstPersonController.enabled = true;
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
		rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
	}
	private void Start()
	{
		HideMenu();
	}
}
