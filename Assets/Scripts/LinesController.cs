using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script assigned to handling the Smiler's taunts towards the player in the City Hall level.
/// </summary>
public class LinesController : MonoBehaviour
{
	#region serializedFields
	[Tooltip("Subtitles used in this sequence.")]
    [SerializeField]
    private Text subtitles;

	[Tooltip("Richard's optimistic intro line, according to script.")]
	[SerializeField]
	private AudioClip RichardLine1;

	[Tooltip("The Smiler's first real line, said over speaker intercom, according to script.")]
	[SerializeField]
	private AudioClip smilerIntercom1;

	[Tooltip("Smiler's less-than-pleased response to when the player opens the storage room.")]
	[SerializeField]
	private AudioClip smilerDisappointedKey;

	[Tooltip("Opening collider to ensure the first lines are played immediately, and that the trigger is disabled afterwards.")]
	[SerializeField]
	private Collider frontDoorLineCollider;

	[Tooltip("The storage room collider that plays Smiler's disappointed line.")]
	[SerializeField]
	private Collider storageRoomCollider;
	#endregion

	private new AudioSource audio;
	private bool isLockerTrigger;
	private int voicelineUpdater = 1;
	private float duration;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		frontDoorLineCollider.enabled = true;
		storageRoomCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("The player entered the trigger");

		if (other.gameObject.CompareTag("Voice1"))
		{
			isLockerTrigger = false;
		}
		else if (other.gameObject.CompareTag("Voice2"))
		{
			isLockerTrigger = true;
		}

		CheckVoiceTriggers();
	}

	private void CheckVoiceTriggers()
	{
		if (voicelineUpdater == 1)
		{
			frontDoorLineCollider.enabled = false;
			duration = RichardLine1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(RichardLine1, 1);
			subtitles.text = "Richard: It's over Smiler! I've got you cornered.";
			StopCoroutine(WaitForSound());
		}
		else if (voicelineUpdater == 2)
		{
			duration = smilerIntercom1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerIntercom1, 1);
			subtitles.text = "Smiler: You may have found my hideout, but you haven't found me yet! Come now, detective. Let’s play one more game before we go.";
			StopCoroutine(WaitForSound());
		}
		else if (voicelineUpdater == 3 && isLockerTrigger == true)
		{
			CheckLockerRoom();
		}
	}

	private void CheckLockerRoom()
	{
		storageRoomCollider.enabled = false;
		duration = smilerDisappointedKey.length;
		StartCoroutine(WaitForSound());
		audio.PlayOneShot(smilerDisappointedKey, 1);
		subtitles.text = "Smiler: Oh, so you’re not as dull as I thought you’d be. Well... That’s disappointing. Moving on.";
		StopCoroutine(WaitForSound());
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
		subtitles.text = "";
		voicelineUpdater++;
		CheckVoiceTriggers();
	}


}
