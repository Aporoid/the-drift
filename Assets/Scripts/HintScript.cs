using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
	[SerializeField]
	private Text peterResponses;

	[SerializeField]
	private Button backButton;

	private new AudioSource audio;
	//public AudioClip[] peterClips = new AudioClip[6];
	public AudioClip peterHint1;
	public AudioClip peterHint2;
	public AudioClip peterHint3;
	public AudioClip peterHint4;
	public AudioClip peterHint5;

	private float duration;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	public void GiveHints()
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
