using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinesController : MonoBehaviour
{
    [SerializeField]
    private Text subtitles;

    private new AudioSource audio;

    public AudioClip RichardLine1;
    public AudioClip smilerIntercom1;
    public AudioClip smilerIntercom2;
    public AudioClip smilerDisappointedKey;
    public AudioClip smilerThroughDoor1;
    public AudioClip smilerThroughDoor2;
    public AudioClip smilerEnd;

	public Collider frontDoorLineCollider;
	//public Collider parkCollider;
	//public Collider graveyardCollider;
	//public Collider barnCollider;

	private int voicelineUpdater = 1;
	private float duration;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		frontDoorLineCollider.enabled = true;
		//parkCollider.enabled = true;
		//graveyardCollider.enabled = true;
		//barnCollider.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("The player entered the trigger");
		CheckVoiceTriggers();
	}

	private void CheckVoiceTriggers()
	{
		if(voicelineUpdater == 1)
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
	}

	IEnumerator WaitForSound()
	{
		yield return new WaitForSeconds(duration);
		subtitles.text = "";
		voicelineUpdater++;
		CheckVoiceTriggers();
	}


}
