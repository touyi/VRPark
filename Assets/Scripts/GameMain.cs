using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameMain : MonoBehaviour
{
	public Transform bornTrans = null;
	private IActor actor = null;
	
	private void Awake()
	{
		actor = PCActor.CreateActor();
		actor.Init();
	}

	private void FixedUpdate()
	{
		
	}

	private void Update()
	{
		if (actor != null)
		{
			actor.Update();
		}
		
	}
}
