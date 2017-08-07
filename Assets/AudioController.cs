using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour 
{
	public static AudioController Instance;
	public AudioSource source;

	private void Awake()
	{
		Instance = this;
	}
	public void Play(AudioClip sound)
	{
		source.clip = sound;
		source.Play();
	}
}
