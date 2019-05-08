using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class milerLineControllerTemp : MonoBehaviour
{
    [Tooltip("Subtitles used in this sequence.")]
    [SerializeField]
    private Text subtitles;

    [Tooltip("Smiler's less-than-pleased response to when the player opens the storage room.")]
    [SerializeField]
    private AudioClip smilerDisappointedKey;

    [Tooltip("The collider around the locker holding Smiler's key. Becomes enabled when the key is picked up.")]
    [SerializeField]
    private Collider smilerKeyCollider;

	[SerializeField]
	private GameObject indicatorText;

    private new AudioSource audio;
    private float duration;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
		indicatorText.SetActive(false);
    }

    private void Update()
    {
        if (InventoryObject.hasSmilersKey == true)
        {
            smilerKeyCollider.enabled = true;
        }
        else if (InventoryObject.hasSmilersKey == false)
        {
            smilerKeyCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckLockerRoom();
    }

    private void CheckLockerRoom()
    {
        duration = smilerDisappointedKey.length;
        StartCoroutine(WaitForSound());
        audio.PlayOneShot(smilerDisappointedKey, 1);
        subtitles.text = "Smiler: Oh, so you’re not as dull as I thought you’d be. Well... That’s disappointing. Moving on.";
		indicatorText.SetActive(true);
        StopCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(duration);
        subtitles.text = "";
    }
}
