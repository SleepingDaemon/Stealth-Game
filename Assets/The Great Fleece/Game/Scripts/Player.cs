using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Animator _anim = null;
    [SerializeField] private GameObject _coin = null;
    [SerializeField] private AudioClip _coinDrop = null;

    private GameObject[] _ai = null;
    private Vector3 _target;

    private bool _hasTossedCoin = false;

    private void Start()
    {
        _ai = GameObject.FindGameObjectsWithTag("Guard1");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            
            if(Physics.Raycast(ray, out _hit))
            {
                _anim.SetBool("isWalking", true);
                _agent.SetDestination(_hit.point);
                _target = _hit.point;
            } 
        }

        if(Vector3.Distance(transform.position, _target) < 1)
        {
            _anim.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(1) && !_hasTossedCoin)
        {
            _hasTossedCoin = true;
            _anim.SetTrigger("throw");

            StartCoroutine(ThrowRoutine());
        }
    }

    private void SendAIToCoinPosition(Vector3 coinPos)
    {
        foreach (var agent in _ai)
        {
            var guardScript = agent.GetComponent<GuardAI>();
            var gaurdAnim = agent.GetComponent<Animator>();
            
            guardScript.CoinDropped();
            
            gaurdAnim.SetBool("isWalking", true);
            guardScript.CoinPos = coinPos;
        }
    }

    private IEnumerator ThrowRoutine()
    {
        yield return new WaitForSeconds(0.8f);
        
        var mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        
        if (Physics.Raycast(mousePos, out _hit))
        {
            var coinInstance = Instantiate(_coin, _hit.point, Quaternion.identity);
            var coinAudioSource = coinInstance.GetComponentInChildren<AudioSource>();
            coinAudioSource.clip = _coinDrop;
            coinAudioSource.Play();
            SendAIToCoinPosition(_hit.point);
        }
    }
}
