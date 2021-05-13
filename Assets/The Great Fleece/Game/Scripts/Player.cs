using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Animator _anim = null;

    private RaycastHit hit;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit))
            {
                _anim.SetBool("isWalking", true);
                _agent.SetDestination(hit.point);
            } 
        }

        if(Vector3.Distance(transform.position, hit.point) < 1)
        {
            _anim.SetBool("isWalking", false);
        }
    }
    
}
