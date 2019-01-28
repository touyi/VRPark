using UnityEngine;
using System.Collections;

public class CollisionStay : MonoBehaviour {

public AudioSource beep;
public float StartTime;
public bool CollidCheck = false;

void Update (){
	if(Time.time - StartTime >= 1 && CollidCheck == true ){
		if(!beep.isPlaying){
			beep.Play();
		}
		
	}

}
/*void OnCollisionStay (){
	if(!beep.isPlaying  ){
		
		Debug.Log("Ay 7aga");
		beep.Play();
	}*/
	
//}
void OnCollisionEnter (){
	CollidCheck = true ;
	StartTime = Time.time;
}

void OnCollisionExit (){
	CollidCheck = false;
}
}