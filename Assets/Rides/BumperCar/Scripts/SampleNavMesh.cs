using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SampleNavMesh : MonoBehaviour {

	public Transform Target;	
	UnityEngine.AI.NavMeshAgent Agent;	

	// Use this for initialization
	void Start () {
		Agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();	
	}
	
	// Update is called once per frame
	void Update () {
		Agent.SetDestination (Target.position);
	}
}
