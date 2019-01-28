using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

    public float delayTime;

    AudioSource audioFile;
    float startTime;
    bool audioPlayed = false;

    void Start (){
        audioFile = GetComponent<AudioSource>();
        startTime = Time.time;
    }

    void Update (){
        if (Time.time - startTime >= delayTime && !audioPlayed)
        {
            audioFile.Play();
            audioPlayed = true;
        }
    }
}