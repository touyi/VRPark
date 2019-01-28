using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioSource Audio;
	public bool delayTime;
	public float timer;

	void OnTriggerEnter(Collider col){
	
		if (delayTime)
		{
			Invoke ("PlaySound", timer);
		} 

		else
		{
			PlaySound();
		}
	}

	void PlaySound()
	{
		Audio.Play ();
	}


}
