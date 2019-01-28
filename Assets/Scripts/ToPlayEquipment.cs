using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ToPlayEquipment : MonoBehaviour
{
	public Animation anim;
	public Transform sitTrans;
	public void OnTriggerPlayEquipment(IActor actor)
	{
		if (actor == null)
		{
			Debug.Log("Actor is null");
			return;
		}

		if (this.sitTrans == null || this.anim == null)
		{
			return;
		}

		Transform actorTrans = actor.GameObjectWrap.transform;
		if (actorTrans)
		{
			actorTrans.SetParent(this.sitTrans);
			actorTrans.localScale = Vector3.one;
			actorTrans.localPosition = Vector3.zero;
			actorTrans.rotation = this.sitTrans.rotation; 
		}
		
	}
}
