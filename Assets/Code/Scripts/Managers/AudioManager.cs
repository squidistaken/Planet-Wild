using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	void Awake()
	{
		
		
		foreach (Sound s in sounds)
		{
			s.audioSource = gameObject.AddComponent<AudioSource>();
			s.audioSource.clip = s.audioClip;

			s.audioSource.volume = s.volume;
			s.audioSource.pitch = s.pitch;
			s.audioSource.spatialBlend = s.spatialBlend;
			s.audioSource.loop = s.loop;
		}
	}

	public void PlayAudio(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null) return;
		s.audioSource.Play();
	}
}
