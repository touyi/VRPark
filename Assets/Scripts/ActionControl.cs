using System;
using UnityEngine;

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
    public class ActionControl
    {
        private float speed = 20;
        public Transform headTrans = null;
        public Vector3 eulerAngle = Vector3.zero;
        public Transform tartgetPoint = null;
        private bool isHaveTarget = false;
        private WeakRef<IActor> actorRef;

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
        }
        public void Update()
        {
            if (headTrans)
            {
                // 方向
                float x = -Input.GetAxis("Mouse Y");
                float y = Input.GetAxis("Mouse X");
                // Vector3 originEulerAngle = this.eulerAngle;
                //Debug.Log(originEulerAngle);
                this.eulerAngle.x += x * Time.deltaTime * speed;
                this.eulerAngle.y += y * Time.deltaTime * speed;
                this.eulerAngle.x = Mathf.Clamp(this.eulerAngle.x, -89, 89);
                this.headTrans.localEulerAngles = this.eulerAngle;
                UpdateViewPoint();
            }

            if (Input.GetMouseButtonDown(0))
            {
                IActor actor = actorRef.Ref;
                if (actor != null)
                {
                    actor.TPPosition(this.tartgetPoint);
                }
            }
            
            
        }

        public void UpdateViewPoint()
        {
            // 视线
            RaycastHit hit;
            if (Physics.Raycast(this.headTrans.position, this.headTrans.forward, out hit))
            {
                if (hit.transform.CompareTag("Walkable"))
                {
                    isHaveTarget = true;
                    this.tartgetPoint.gameObject.CustomActive(true);
                    this.tartgetPoint.position = hit.point;
                    return;
                }
                    
            }

            isHaveTarget = false;
            this.tartgetPoint.gameObject.CustomActive(false);
        }

        
        
    }
}
