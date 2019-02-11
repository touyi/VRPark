using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ToPlayEquipment : MonoBehaviour
{
	public float MaxPlayTime = -1f;
	private float currentPlayTime = 0;
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
			this.currentPlayTime = 0;
		}
		
	}

	public void OnEquipEnd()
	{
		// 返回原位置
		if (this.currentSitActor == null)
		{
			return;
		}

		if (this.anim)
		{
			this.anim.Stop();
		}
		
		this.currentSitActor.GameObjectWrap.transform.SetParent(null);
		this.currentSitActor.TPPosition(this.originPosition);
		this.currentSitActor.GameObjectWrap.transform.eulerAngles = this.originEulerAngle;
		this.currentSitActor.GameObjectWrap.transform.localScale = Vector3.one;
		this.currentSitActor.ActionControl.ActiveMove();
		this.currentSitActor = null;
		isPlay = false;
		this.currentPlayTime = 0;
	}

	private void Update()
	{
		if (!this.anim)
		{
			return;
		}
		if (this.anim && isPlay && !this.anim.isPlaying)
		{
			this.OnEquipEnd();
		}

		if (this.anim.isPlaying && this.MaxPlayTime > 0f)
		{
			this.currentPlayTime += Time.deltaTime;
			if (this.currentPlayTime > this.MaxPlayTime)
			{
				this.OnEquipEnd();
			}
		}
	}
}
