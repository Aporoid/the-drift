using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject inventoryMenuItemTogglePrefab;

	private static InventoryMenu instance;
	private CanvasGroup canvasGroup;
	private RigidbodyFirstPersonController rigidbodyFirstPersonController;
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
		Instantiate(inventoryMenuItemTogglePrefab);
	}

	private void ShowMenu()
	{
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
		rigidbodyFirstPersonController.enabled = false;
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
		rigidbodyFirstPersonController.enabled = true;
		audioSource.Play();
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
