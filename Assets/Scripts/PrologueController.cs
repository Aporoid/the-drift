using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueController : MonoBehaviour
{
	[SerializeField]
	private Text prologueSubtitles;

	[SerializeField]
	private GameObject loadingScreen;

	private new AudioSource audio;
	//public AudioClip[] peterClips = new AudioClip[6];
	public AudioClip line1;
	public AudioClip line2;
	public AudioClip line3;
	public AudioClip line4;
	public AudioClip line5;
	public Image badge;
	public Image noteImage;
	public Image churchImage;

	private int lineCount;
	private float duration;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		badge.enabled = false;
		noteImage.enabled = false;
		churchImage.enabled = false;
		Narration();
	}

	private void Narration()
	{
		if(lineCount == 0)
		{
			duration = line1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(line1, 1);
			prologueSubtitles.text = "Alright, let's get this over with, for the records.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 1)
		{
			badge.enabled = true;
			duration = line2.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(line2, 1);
			prologueSubtitles.text = "My name is Richard Dahl. I am a private detective on the Alabama Police force, and I've been tasked with finding a serial killer who's nicknamed themselves 'The Smiler'. They're evasive, but sloppy; and they love leaving a calling card over their victims... One of which was my wife.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 2)
		{
			duration = line3.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(line3, 1);
			prologueSubtitles.text = "I’ve tracked them to the abandoned city of Wasburn. I don’t know the full story of the town, but records say the mayor went insane and drove all the citizens out. Where the mayor is now, if he’s still alive, is currently unknown.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 3)
		{
			noteImage.enabled = true;
			duration = line4.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(line4, 1);
			prologueSubtitles.text = "The strange part is they’re leaving me clues, it’s almost like they want to be found. This is the best lead I have, so I guess I have to play their little game.";
			StopCoroutine(WaitForSound());
		}
		if (lineCount == 4)
		{
			churchImage.enabled = true;
			duration = line5.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(line5, 1);
			prologueSubtitles.text = "I took shelter at one of Wasburn’s churches, just to get out of the rain for the night. Luckily, the electricity is still on. Best get some shut-eye if I’m going to find them. Dahl out.";
			StopCoroutine(WaitForSound());
		}
		if(lineCount == 5)
		{
			prologueSubtitles.text = "";
			loadingScreen.SetActive(true);
			StartCoroutine(Countdown());
		}
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
		lineCount++;
		Narration();
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(2);
	}
}
