using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour 
{
    [SerializeField] private Transform _camAngle = null;

	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Activated");
            var cam = Camera.main;

            _camAngle.gameObject.SetActive(true);
            cam.transform.position = _camAngle.position;
            cam.transform.rotation = _camAngle.rotation;
        }
    }
}
