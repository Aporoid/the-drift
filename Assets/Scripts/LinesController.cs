using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinesController : MonoBehaviour
{
    //[SerializeField]
    //private text subtitles;

    private new AudioSource audio;

    public AudioClip RichardLine1;

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


}
