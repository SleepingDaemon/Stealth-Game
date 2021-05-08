using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
    [SerializeField] private NavMeshAgent _agent = null;

    private void Update()
    {
        //if left click
        if(Input.GetMouseButtonDown(0))
        {
            //cast a ray from the mouse position
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit))
            {
                //debug the floor position hit
                Debug.Log(hit.point);

                //create object at floor position to know the floor has been hit.
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = hit.point;
                //Instantiate(sphere, hit.point, Quaternion.identity);

                _agent.SetDestination(hit.point);
            }
        }
    }
    
}
