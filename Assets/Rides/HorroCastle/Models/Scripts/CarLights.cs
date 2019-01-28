using UnityEngine;
using System.Collections;

public class CarLights : MonoBehaviour {

	public GameObject lightToActivate;
	Animation anim;
	
	void OnTriggerEnter(Collider col) {
		
		lightToActivate.SetActive(true);
		anim.Play();
		
	}
	
	void Start(){
		
		lightToActivate.SetActive(false);
		anim = lightToActivate.GetComponent<Animation>();
	}
}

