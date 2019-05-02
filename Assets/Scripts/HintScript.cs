using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
	#region serializedFields
	[Tooltip("The subtitles within the pop-up box when requesting a hint.")]
	[SerializeField]
	private Text peterResponses;

	[Tooltip("The button to exit the hint pop-up. Becomes disabled until the audio is played at least once over.")]
	[SerializeField]
	private Button backButton;

	[Tooltip("Peter's first line regarding the overlook clue.")]
	[SerializeField]
	private AudioClip peterHint1;

	[Tooltip("Peter's second line regarding the greenhouse clue.")]
	[SerializeField]
	private AudioClip peterHint2;

	[Tooltip("Peter's third line regarding the graveyard clue.")]
	[SerializeField]
	private AudioClip peterHint3;

	[Tooltip("Peter's fourth line regarding the barnyard clue.")]
	[SerializeField]
	private AudioClip peterHint4;

	[Tooltip("Peter's fifth line regarding the city hall clue.")]
	[SerializeField]
	private AudioClip peterHint5;
	#endregion

	private new AudioSource audio;
	private float duration;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	public void GiveHints() // used to give both visual and audio cues for when the player requests help from the inventory menu.
	{
		if (InventoryObject.clueNumber == 1)
		{
			backButton.enabled = false;
			duration = peterHint1.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(peterHint1, 1);
			peterResponses.text = "Uhhhh, sounds like it’s put between a couple of light posts out on the waterfront. Try finding an area where there’s two right next to each other in a row, near the water. That’s best I got, sorry Rick.";
			StopCoroutine(WaitForSound());
			backButton.enabled = true;
		}
		else if (InventoryObject.clueNumber == 2)
		{
			backButton.enabled = false;
			duration = peterHint2.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(peterHint2, 1);
			peterResponses.text = "I mean, my first instinct is to go where plants are, like a garden or something. But 'panes of tinted glass' makes me think it's like a greenhouse. Try there.";
			StopCoroutine(WaitForSound());
			backButton.enabled = true;
		}
		else if (InventoryObject.clueNumber == 3)
		{
			backButton.enabled = false;
			duration = peterHint3.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(peterHint3, 1);
			peterResponses.text = "Hmm, if I’m to take a wild guess, this sounds like a funeral home or a graveyard to me. I’m not too much a fan of those places after my uncle Jacob…" + "\n" + " actually never mind, just do what you need to. Cemeteries or Funeral home";
			StopCoroutine(WaitForSound());
			backButton.enabled = true;
		}
		else if (InventoryObject.clueNumber == 4)
		{
			backButton.enabled = false;
			duration = peterHint4.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(peterHint4, 1);
			peterResponses.text = "Well obviously it makes it sound like you need a key, and if I’m thinking about crowns, that’s probably a deed. Barnyard blues has me thinking that it’s around a farm or something, so the key can’t be too far. Try a farm.";
			StopCoroutine(WaitForSound());
			backButton.enabled = true;
		}
		else if (InventoryObject.clueNumber == 5)
		{
			backButton.enabled = false;
			duration = peterHint5.length;
			StartCoroutine(WaitForSound());
			audio.PlayOneShot(peterHint5, 1);
			peterResponses.text = "C’mon Rick, what else in a town has that much priority? Well, aside from its citizens, livestock, building codes, pie... right, rambling, I think it’s city hall. I’m getting a snack.";
			StopCoroutine(WaitForSound());
			backButton.enabled = true;
		}
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
	}
}
