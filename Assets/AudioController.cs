using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
	public static AudioController Instance;

    public AudioSource[] AudioSources;

    private int index = 0;

	private void Awake()
	{
		Instance = this;
	}
	public void Play(AudioClip sound)
	{
        AudioSources[index].clip = sound;
        AudioSources[index].Play();
        index = index < AudioSources.Length - 1 ? index + 1 : 0;
    }
}
