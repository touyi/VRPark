using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour 
{
    public Image loadingImage;
    public Animator exitButtonAnimator;

    private AsyncOperation operation;


    public void LoadLevel(int level)
    {
        StartCoroutine(LoadLevelAsync(level));
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevelAsync(int _level)
    {
        yield return new WaitForSeconds(0.1f);

        if(loadingImage != null)
        {
            loadingImage.gameObject.SetActive(true);
        }

        operation = SceneManager.LoadSceneAsync(_level);

        while(!operation.isDone)
        {
            if(loadingImage != null)
            {
                loadingImage.transform.GetChild(0).GetComponent<Image>().fillAmount = operation.progress;
            }
            yield return null;
        }
    }

    IEnumerator LoadMainMenu()
    {
        if(exitButtonAnimator != null)
        {
            exitButtonAnimator.SetTrigger("Exit");
        }
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(1);
    }
}
