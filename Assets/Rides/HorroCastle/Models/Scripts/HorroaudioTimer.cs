using UnityEngine;
using System.Collections;

public class HorroaudioTimer : MonoBehaviour {
 AudioSource AudioFile;
 float timer = 4.5f;
 //float endTime = 10;
 float StartTime = 0;
 bool enterd = false;
 void Start (){
 	StartTime = Time.time;
 }
 
 void Update (){
     
     if (!AudioFile.isPlaying && (Time.time - StartTime) >= timer && enterd==false) {
     	enterd=true;
        AudioFile.Play();
         //if (!AudioFile.isPlaying && Time.time > timer ){
 		//	AudioFile.Play();
	 	}
		
}		 
        
        
    //else if (foo.isPlaying && Time.time > 5 ){
    	//foo.Pause();
     //else {
      //foo.Pause();
     //}	
    

}