using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private Image _barImage = null;

    private void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);

        while (!asyncOperation.isDone)
        {
            _barImage.fillAmount = asyncOperation.progress;

            yield return new  WaitForEndOfFrame();
        }
    }
}
