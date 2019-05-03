using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Script responsible for the final dialogue within City Hall. This script also includes the scripting for the final cutscene.
/// </summary>
public class FinaleScript : MonoBehaviour
{
	#region serializedfields
	[Tooltip("The subtitles for this scene.")]
	[SerializeField]
	private Text subtitles;

	[Tooltip("The last of Smiler's audio clips over intercom.")]
	[SerializeField]
	private AudioClip smilerLine1;

	[Tooltip("The Smiler line of him talking through the door, 1st time.")]
	[SerializeField]
	private AudioClip smilerLine2ThroughDoor;

	[Tooltip("The Smiler line of him talking through the door, 2nd time.")]
	[SerializeField]
	private AudioClip smilerLine3ThroughDoor;

	[Tooltip("The Smiler line of him talking naturally, after opening the door and speaking face-to-face.")]
	[SerializeField]
	private AudioClip smilerEnding;

	[Tooltip("The trigger box that causes the final cutscene.")]
	[SerializeField]
	private Collider finalCollider;

	[Tooltip("The First person controller currently operating for the player.")]
	[SerializeField]
	private FirstPersonController characterController;

    [Tooltip("The section of the HUD used to indicate pop-up buttons in the top left.")]
    [SerializeField]
    private GameObject HUDCanvasTopLeft;
    
    [Tooltip("The canvas used to create the cinematic black bars on the screen.")]
	[SerializeField]
	private Canvas endgameCanvas;

	[Tooltip("The pure black image that overrides all sight for the dramatic ending.")]
	[SerializeField]
	private Image blackScreen;

	[Tooltip("The camera component used by the player controller, accessed to freeze their directional facing for the cutscene.")]
	[SerializeField]
	private Camera cam;
	#endregion

	private new AudioSource audio;
	public AudioClip gunshot;
	public AudioClip doorOpen;
	public Transform target;
	public Transform target2;

	private int lineCount;
	private float duration;
	public static bool isDying;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		endgameCanvas.enabled = false;
		blackScreen.enabled = false;
		isDying = false;
	}

	private void Update()
	{
		CheckForKey();
	}

	private void CheckForKey() // Used to test if the player has Smiler's Key or not. If not, the trigger is disabled.
	{
		if(InventoryObject.hasSmilersKey == true)
		{
			finalCollider.enabled = true;
		}
		else if (InventoryObject.hasSmilersKey == false)
		{
			finalCollider.enabled = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Ending();
	}

	private void Ending() // This is the final cutscene. Coded in such a way so that the player is entirely motionless and stuck looking at a certain point, as per cutscene standards.
	{
		HUDCanvasTopLeft.SetActive(false);
		cam.transform.LookAt(target);
		endgameCanvas.enabled = true;
		characterController.enabled = false;
		if(lineCount == 0)
		{
			duration = smilerLine1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerLine1, 1);
			subtitles.text = "Smiler: Oh, you poor, lost detective. You honestly thought I’d give up that easily?";
			StopCoroutine(WaitForSound());
		}
		if(lineCount == 1)
		{
			duration = gunshot.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(gunshot, 1);
			subtitles.text = "*BANG*";
			StopCoroutine(WaitForSound());
            isDying = true;
            PlayerAnimationController.PlayerFallsDown();
		}
		if (lineCount == 2)
		{
			cam.transform.LookAt(target2);
			duration = smilerLine2ThroughDoor.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerLine2ThroughDoor, 1);
			subtitles.text = "Smiler [muffled]: Listen up, detective. Your wife was just as stubborn as you are.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 3)
		{
			duration = doorOpen.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(doorOpen, 1);
			subtitles.text = "";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			duration = smilerEnding.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerEnding, 1);
			subtitles.text = "Smiler: Goodbye, detective.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 5)
		{
			duration = gunshot.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(gunshot, 1);
			blackScreen.enabled = true;
			subtitles.text = "";
			StopCoroutine(WaitForSound());
			SceneManager.LoadScene(4);
		}
	}

	IEnumerator WaitForSound() //Used to advance to the next line in the script.
	{
		yield return new WaitForSeconds(duration);
		lineCount++;
		Ending();
	}

}
