using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinaleScript : MonoBehaviour
{
	[SerializeField]
	private Text subtitles;

	public AudioClip smilerLine1;
	public AudioClip smilerLine2ThroughDoor;
	public AudioClip smilerLine3ThroughDoor;
	public AudioClip smilerEnding;
	public AudioClip richardGroan;
	public AudioClip gunshot;
	public AudioClip doorOpen;
	public Collider finalCollider;

	private int lineCount;
	private float duration;

	private new AudioSource audio;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		CheckForKey();
	}

	private void CheckForKey()
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

	private void Ending()
	{
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
		}
		if (lineCount == 2)
		{
			duration = richardGroan.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(richardGroan, 1);
			subtitles.text = "Richard: Augh!!";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 3)
		{
			duration = smilerLine2ThroughDoor.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerLine2ThroughDoor, 1);
			subtitles.text = "Smiler [muffled]: Listen up, detective. Your wife was just as stubborn as you are.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			duration = doorOpen.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(doorOpen, 1);
			subtitles.text = "";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 5)
		{
			duration = smilerEnding.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(smilerEnding, 1);
			subtitles.text = "Smiler: Goodbye, detective.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 6)
		{
			duration = gunshot.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(gunshot, 1);
			subtitles.text = "*BANG*";
			StopCoroutine(WaitForSound());
		}
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
		lineCount++;
		Ending();
	}

}
