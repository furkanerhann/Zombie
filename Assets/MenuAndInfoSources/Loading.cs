using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject buttonToClose;
    public Image loadingBarFill;

    public void LoadScreen()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        loadingScreen.SetActive(true);
        buttonToClose.SetActive(false);
        loadingBarFill.fillAmount = 0.0f;
        yield return new WaitForSeconds(1f);
        loadingBarFill.fillAmount = 0.2f;
        yield return new WaitForSeconds(1f);
        loadingBarFill.fillAmount = 0.5f;
        yield return new WaitForSeconds(2f);
        loadingBarFill.fillAmount = 0.9f;
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
