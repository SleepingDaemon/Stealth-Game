using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
	[SerializeField] private AudioSource _camAudioSource = null;
	[SerializeField] private AudioClip _audioClip = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (_camAudioSource != null)
			{
				_camAudioSource.clip = _audioClip;
				_camAudioSource.Play();
			}
		}
	}
}
