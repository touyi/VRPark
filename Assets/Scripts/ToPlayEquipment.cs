using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ToPlayEquipment : MonoBehaviour
{
	public Animation anim;
	public Transform sitTrans;
	public Transform originTrans;
	public IActor currentSitActor = null;
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

		this.originTrans = actor.GameObjectWrap.transform;
		Transform actorTrans = actor.GameObjectWrap.transform;
		if (actorTrans)
		{
			actorTrans.SetParent(this.sitTrans);
			actorTrans.localScale = Vector3.one;
			actorTrans.localPosition = Vector3.zero;
			actorTrans.rotation = this.sitTrans.rotation; 
		}

		this.currentSitActor = actor;
	}

	public void OnEquipEnd()
	{
		// 返回原位置
		if (this.currentSitActor == null || this.originTrans == null)
		{
			return;
		}

		this.currentSitActor.TPPosition(this.originTrans);
		this.currentSitActor = null;
	}
}
