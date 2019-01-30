using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ToPlayEquipment : MonoBehaviour
{
	public Animation anim;
	public Transform sitTrans;
	private Vector3 originPosition;
	private Vector3 originEulerAngle;
	private IActor currentSitActor = null;
	private bool isPlay = false;
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

		this.originPosition = actor.GameObjectWrap.transform.position;
		this.originEulerAngle = actor.GameObjectWrap.transform.eulerAngles;
		Transform actorTrans = actor.GameObjectWrap.transform;
		if (actorTrans)
		{
			actorTrans.SetParent(this.sitTrans);
			actorTrans.localScale = Vector3.one;
			actorTrans.localPosition = Vector3.zero;
			actorTrans.rotation = this.sitTrans.rotation; 
		}

		this.currentSitActor = actor;
		actor.ActionControl.DisableMove();
		if (this.anim)
		{
			this.anim.Play();
			isPlay = true;
		}
		
	}

	public void OnEquipEnd()
	{
		// 返回原位置
		if (this.currentSitActor == null)
		{
			return;
		}

		this.currentSitActor.GameObjectWrap.transform.SetParent(null);
		this.currentSitActor.TPPosition(this.originPosition);
		this.currentSitActor.GameObjectWrap.transform.eulerAngles = this.originEulerAngle;
		this.currentSitActor.ActionControl.ActiveMove();
		this.currentSitActor = null;
		isPlay = false;
	}

	private void Update()
	{
		if (this.anim && isPlay && !this.anim.isPlaying)
		{
			this.OnEquipEnd();
		}
	}
}
