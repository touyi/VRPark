using UnityEngine;
using System.Collections;

public class DynamicLightsActivator : MonoBehaviour {

	public GameObject[] lights;


	// Use this for initialization
	void Start () {
		foreach(GameObject go in lights)
		{
			go.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
