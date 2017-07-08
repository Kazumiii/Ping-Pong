using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public static SoundManager Instant = null;
    public AudioClip goolBloop;
    public AudioClip lossBloop;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;


    private AudioSource soundeffectAudio;

    // Use this for initialization
    void Start () {
		

        if(Instant==null)
        {
            Instant = this;
        }
        else if(Instant!=this)
        {
            Destroy(gameObject);
        }


        AudioSource[] sources=GetComponents<AudioSource>();

        foreach(AudioSource audio in sources)
        {
            if(audio.clip==null)
            {
                soundeffectAudio = audio;
            }
        }
	}


    public void PlayOneShoot(AudioClip clip)
    {
        soundeffectAudio.PlayOneShot(clip);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
