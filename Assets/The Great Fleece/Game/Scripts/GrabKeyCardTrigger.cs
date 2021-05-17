using UnityEngine;

public class GrabKeyCardTrigger : MonoBehaviour
{
	[SerializeField] private GameObject _keyCardCutscene = null;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_keyCardCutscene.SetActive(true);
			GameManager.Instance.HasCard = true;
		}
	}
}
