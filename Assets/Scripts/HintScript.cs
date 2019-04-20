using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
	[SerializeField]
	private Text peterResponses;

	private AudioSource audio;
	//public AudioClip[] peterClips = new AudioClip[6];
	public AudioClip peterHint1;
	public AudioClip peterHint2;
	public AudioClip peterHint3;
	public AudioClip peterHint4;
	public AudioClip peterHint5;
	public AudioClip peterHint6;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	public void GiveHints()
	{
		if (InventoryObject.clueNumber == 1)
		{
			audio.PlayOneShot(peterHint1, 1);
			peterResponses.text = "Uhhhh, sounds like it’s put between a couple of light posts. Try finding an area where there’s two right next to each other in a row, like buoys on a dock.That’s best I got, sorry Rick.";
		}
		else if (InventoryObject.clueNumber == 2)
		{
			audio.PlayOneShot(peterHint2, 1);
			peterResponses.text = "I mean, my first instinct is to go where plants are, like a garden or something. But 'panes of tinted glass' makes me think it's like a greenhouse or something. Try there.";
		}
		else if (InventoryObject.clueNumber == 3)
		{
			audio.PlayOneShot(peterHint3, 1);
			peterResponses.text = "Hmm, if I’m to take a wild guess, this sounds like a funeral home or a graveyard to me. I’m not too much a fan of those places after my uncle Jacob…" + "\n" + " actually never mind, just do what you need to. Cemeteries or Funeral home";
		}
		else if (InventoryObject.clueNumber == 4)
		{
			audio.PlayOneShot(peterHint4, 1);
			peterResponses.text = "Well obviously it makes it sound like you need a key, but most doors normally open in or out according to code. So only door I can think of that slides is a barn door. Try there maybe?";
		}
		else if (InventoryObject.clueNumber == 5)
		{
			audio.PlayOneShot(peterHint5, 1);
			peterResponses.text = "Now my aunt Maria is a much more religious person than I am, but I know what worship normally means. Try poking around the local church, maybe you'll find something there.";
		}
		else if (InventoryObject.clueNumber == 6)
		{
			audio.PlayOneShot(peterHint6, 1);
			peterResponses.text = "C'mon Rick, what else in town has that much priority? Well, aside from citizens, livestock, building codes, pie... Right, rambling, I think it's City Hall. I'm getting a snack.";
		}
	}
}
