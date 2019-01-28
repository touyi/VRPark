using UnityEngine;
using System.Collections;

public class LightActivator : MonoBehaviour {

	public Animator toActivate;

	void OnTriggerEnter(Collider col) {

		toActivate.enabled = true;

	}

	void Start(){

		toActivate.enabled = false;
	}
}
