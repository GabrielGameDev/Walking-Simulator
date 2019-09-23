using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
		audioSource = GetComponent<AudioSource>();
    }

   public void PlayAudio(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
