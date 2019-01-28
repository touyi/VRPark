using UnityEngine;
using System.Collections;

public class AnimationPlayer : MonoBehaviour {
	public GameObject obj;
	Animation anim;
	void OnTriggerEnter(Collider col) {

		anim.Play();
	}

	void Start(){

		anim = obj.GetComponent<Animation> ();

	}
}
