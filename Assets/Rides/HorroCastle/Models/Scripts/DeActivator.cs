using UnityEngine;
using System.Collections;

public class DeActivator : MonoBehaviour {

	public GameObject obj;

	
	void OnTriggerEnter(Collider col) {
		
		obj.SetActive(false);

	}

}