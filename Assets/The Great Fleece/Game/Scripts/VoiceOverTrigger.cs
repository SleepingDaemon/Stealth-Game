using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
	[SerializeField] private AudioClip _audioClip = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			AudioManager.Instance.PlayVoiceOver(_audioClip);
		}
	}
}
