using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

    public AudioSource crash;
    public AudioSource beep;

    bool collided = false;
    float timer;

    void Update()
    {
        if (Time.time - timer > 0.8f && !beep.isPlaying && collided == true)
        {
            beep.Play();
        }
    }
    void OnCollisionEnter ()
    {
	    crash.Play();
        collided = true;
        timer = Time.time;
    }

    void OnCollisionExit()
    {
        collided = false;
    }


}