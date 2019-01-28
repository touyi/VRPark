using UnityEngine;
using System.Collections;

public class Cloth : MonoBehaviour {

AudioSource cloth;
void OnCollisionEnter (){

	if(!cloth.isPlaying){
		cloth.Play();
	}

}
}