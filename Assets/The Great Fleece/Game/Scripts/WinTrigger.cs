using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var hasCard = GameManager.Instance.HasCard;

            if (hasCard == true)
            {
                _winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You must grab the key card!");
            }
        }
    }
}
