using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour {

    public Transform target;
	
	void Update () {

		Vector3 euler = target.rotation.eulerAngles;
        Quaternion rot = Quaternion.Euler(0, 0, euler.y * -1);
        transform.localRotation = rot;

    }
}
