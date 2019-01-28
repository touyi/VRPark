using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VideoInfo : MonoBehaviour
{
    [SerializeField]
    private string videoTitle;
    [SerializeField]
    private string difficulty;
    [SerializeField]
    private int levelNumber;


    public string VideoTitle
    {
        get { return videoTitle; }
        private set { }
    }

    public string Difficulty
    {
        get { return difficulty; }
        private set { }
    }

    public int LevelNumber
    {
        get { return levelNumber; }
        private set { }
    }

}
