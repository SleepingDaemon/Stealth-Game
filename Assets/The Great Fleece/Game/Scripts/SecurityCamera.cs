using System.Collections;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
	[SerializeField] private GameObject _gameOver = null;
	[SerializeField] private Material _red = null;
	[SerializeField] private Animator _anim = null;

	private MeshRenderer _rend = null;

	private void Awake()
	{
		_rend = GetComponent<MeshRenderer>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_rend.material = _red;
			_anim.enabled = false;
			StartCoroutine(DelayCutsceneRoutine());
		}
	}

	private IEnumerator DelayCutsceneRoutine()
	{
		yield return new WaitForSeconds(0.5f);
		_gameOver.SetActive(true);
	}
}
