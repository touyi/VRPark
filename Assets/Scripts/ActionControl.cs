#define VRMODE
using System;
using System.Net;
using UnityEngine;
using Valve.VR;

namespace DefaultNamespace
{
    public static class GameObjectEx
    {
        public static void CustomActive(this GameObject go, bool isActive)
        {
            if (go && go.activeSelf != isActive)
            {
                go.SetActive(isActive);
            }
        }
    }
    public class ActionControl : IActionControl
    {
        private float speed = 20;
        public Transform headTrans = null;
        public Vector3 eulerAngle = Vector3.zero;
        public Transform tartgetPoint = null;
        private bool isHaveTarget = false;
        private WeakRef<IActor> actorRef;
        private Renderer targetRender = null;
        private ToPlayEquipment playEquipment = null;
        private bool isActive = true;

        public void Init(IActor actor)
        {
            Camera camera = actor.GameObjectWrap.GetComponentInChildren<Camera>();
            if (camera)
            {
                headTrans = camera.transform;
                eulerAngle = Vector3.zero;
            }

            GameObject go = Resources.Load<GameObject>("Prefabs/TargetPoint");
            go = GameObject.Instantiate(go);
            this.tartgetPoint = go.transform;
            actorRef = new WeakRef<IActor>(actor);
            this.targetRender = this.tartgetPoint.GetComponent<Renderer>();
        }
        public void Update()
        {
            if (headTrans)
            {
#if !VRMODE
                // 方向
                float x = -Input.GetAxis("Mouse Y");
                float y = Input.GetAxis("Mouse X");
                // Vector3 originEulerAngle = this.eulerAngle;
                //Debug.Log(originEulerAngle);
                this.eulerAngle.x += x * Time.deltaTime * speed;
                this.eulerAngle.y += y * Time.deltaTime * speed;
                this.eulerAngle.x = Mathf.Clamp(this.eulerAngle.x, -89, 89);
                this.headTrans.localEulerAngles = this.eulerAngle;
#endif
                if (isActive)
                {
                    UpdateViewPoint();
                }
                    
            }
            
            if ((Input.GetMouseButtonDown(0) || SteamVR_Actions._default.ok.GetStateDown(SteamVR_Input_Sources.Any)) && isActive)
            {
                IActor actor = actorRef.Ref;
                if (actor != null)
                {
                    if (this.playEquipment)
                    {
                        this.playEquipment.OnTriggerPlayEquipment(actor);
                    }
                    else
                    {
                        actor.TPPosition(this.tartgetPoint);
                    }
                    
                }
            }
            
            
        }

        public void DisableMove()
        {
            isActive = false;
            this.tartgetPoint.gameObject.CustomActive(false);
        }


        public void ActiveMove()
        {
            isActive = true;
        }
        
        public void UpdateViewPoint()
        {
            // 视线
            RaycastHit hit;
            if (Physics.Raycast(this.headTrans.position, this.headTrans.forward, out hit))
            {
                isHaveTarget = true;
                if (hit.transform.CompareTag("Walkable") || hit.transform.CompareTag("Trigger"))
                {
                    this.tartgetPoint.gameObject.CustomActive(true);
                    this.tartgetPoint.position = hit.point;
                }
                if (this.targetRender)
                {
                    if (hit.transform.CompareTag("Trigger"))
                    {
                        this.targetRender.material.SetColor("_Color", Color.green);
                        this.tartgetPoint.transform.position = hit.transform.position;
                        var handle = hit.transform.GetComponent<ToPlayHandle>();
                        if (handle)
                        {
                            this.playEquipment = handle.ToPlayEquipment;
                        }
                    }
                    else
                    {
                        this.targetRender.material.SetColor("_Color", Color.red);
                        this.playEquipment = null;
                    }
                }
                return;   
            }

            isHaveTarget = false;
            this.tartgetPoint.gameObject.CustomActive(false);
        }

        
        
    }
}
