using UnityEngine;

public class LookAtPlayer : MonoBehaviour 
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _camStart = null;

    private void Start()
    {
        transform.position = _camStart.position;
        transform.rotation = _camStart.rotation;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }
}
