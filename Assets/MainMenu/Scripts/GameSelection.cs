using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSelection : MonoBehaviour
{
    public GameObject rootObject;
    public Camera billboardSelectionCamera;
    public Text videoTitleText;
    public Text difficultyText;
    [Space(10)]
    public float addedAngle = 24;

    public Canvas loadingCanvas;
    public Image loadingBar;

    private AsyncOperation operation;
    private int levelToLoad = 1;
    
    private float angleY = 0;
    private float currentAngle = 0;
    private float prevAngle = 0;

    void Start()
    {
        RaycastHit hit;
        Ray ray = new Ray(billboardSelectionCamera.transform.position, billboardSelectionCamera.transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("MoviePlane")))
        {
            VideoInfo info = hit.collider.GetComponent<VideoInfo>();
            videoTitleText.text = info.VideoTitle;
            difficultyText.text = info.Difficulty;
            levelToLoad = info.LevelNumber;
        }
    }

    public void NextGame()
    {
        currentAngle = currentAngle + addedAngle;
         
        StopCoroutine("LerpAngle");
        StartCoroutine("LerpAngle");
    }

    public void PreviousGame()
    {
        currentAngle = currentAngle - addedAngle;

        StopCoroutine("LerpAngle");
        StartCoroutine("LerpAngle");
    }

    IEnumerator LerpAngle()
    {
        float percent = 0;
        float startAngle = prevAngle;
        float endAngle = currentAngle;

       

        while (percent <= 1)
        {
            percent += Time.deltaTime * 2f;

            angleY = Mathf.Lerp(startAngle, endAngle, percent);

            angleY = angleY % 360;
            rootObject.transform.rotation = Quaternion.Euler(0, angleY, 0);

            yield return null;
        }

        prevAngle = currentAngle;

        RaycastHit hit;
        Ray ray = new Ray(billboardSelectionCamera.transform.position, billboardSelectionCamera.transform.forward);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("MoviePlane")))
        {
            VideoInfo videoInfo = hit.collider.GetComponent<VideoInfo>();
            videoTitleText.text = videoInfo.VideoTitle;
            difficultyText.text = videoInfo.Difficulty;
            levelToLoad = videoInfo.LevelNumber;
        }
    }


    public void LoadLevel()
    {

        RaycastHit hit;
        //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        Ray ray = new Ray(Camera.main.transform.position, Vector3.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("MoviePlane")))
        {
            VideoInfo videoInfo = hit.collider.GetComponent<VideoInfo>();
            
            if(videoInfo.LevelNumber == levelToLoad)
            {
                loadingCanvas.gameObject.SetActive(true);

                StartCoroutine(LoadLevelAsync(levelToLoad));
            }
        }
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadLevelAsync(int _level)
    {
        yield return new WaitForSeconds(0.1f);

        operation = SceneManager.LoadSceneAsync(_level);

        while (!operation.isDone)
        {
            loadingBar.GetComponent<Image>().fillAmount = operation.progress;
            yield return null;
        }
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
    }
}
