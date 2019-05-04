using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject inventoryMenuItemTogglePrefab;

	[Tooltip("The content of the scroll view for the list of inventory items")]
	[SerializeField]
	private Transform inventoryListContentArea;

	[Tooltip("Place in the UI for displaying the name of the selected inventory item.")]
	[SerializeField]
	private Text itemLabelText;

	[Tooltip("Place in the UI for displaying the info of the selected inventory item.")]
	[SerializeField]
	private Text descriptionAreaText;

	private static InventoryMenu instance;
	private CanvasGroup canvasGroup;
	private FirstPersonController firstPersonController;
	private AudioSource audioSource;

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

	/// <summary>
	/// Instantiates a new InventoryMenuItemToggle prefab, and adds it to your inventory menu.
	/// </summary>
	/// <param name="inventoryObjectToAdd"></param>
	public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
	{
		GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
		InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
		toggle.AssociatedInventoryObject = inventoryObjectToAdd;
	}

	private void ShowMenu()
	{
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		firstPersonController.enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		audioSource.Play();
	}

	private void HideMenu()
	{
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		firstPersonController.enabled = true;
		audioSource.Play();
	}

	/// <summary>
	/// This is the event handler for InventoryMenuItemSelected.
	/// </summary>
	private void onInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
	{
		itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
		descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
	}

	private void OnEnable()
	{
		InventoryMenuItemToggle.InventoryMenuItemSelected += onInventoryMenuItemSelected;
	}

	private void OnDisable()
	{
		InventoryMenuItemToggle.InventoryMenuItemSelected -= onInventoryMenuItemSelected;
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
		firstPersonController = FindObjectOfType<FirstPersonController>();
		audioSource = GetComponent<AudioSource>();
	}
	private void Start()
	{
		HideMenu();
		StartCoroutine(WaitForAudioClip());
	}

	private IEnumerator WaitForAudioClip()
	{
		float orignalVolume = audioSource.volume;
		audioSource.volume = 0;
		yield return new WaitForSeconds(audioSource.clip.length);
		audioSource.volume = orignalVolume;
	}
}
