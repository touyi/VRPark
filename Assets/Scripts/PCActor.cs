using UnityEngine;

namespace DefaultNamespace
{
    public class PCActor : IActor
    {
        public static IActor CreateActor()
        {
            GameObject actorGo = Resources.Load<GameObject>("Prefabs/Actor");
            actorGo = GameObject.Instantiate(actorGo);
            if (actorGo == null)
            {
                Debug.Log("actorGo is null");
                return null;
            }
            PCActor actor = new PCActor();
            actor.GameObjectWrap = actorGo;
            return actor;
        }

        public GameObject GameObjectWrap { get; private set; }
        private ActionControl actionControl = null;
        
        public void TPPosition(Vector3 worldPosition)
        {
            if (this.GameObjectWrap)
            {
                this.GameObjectWrap.transform.position = worldPosition;
            }
        }

        public void TPPosition(Transform transform)
        {
            if (transform == null || this.GameObjectWrap == null)
            {
                return;
            }
            this.GameObjectWrap.transform.position = transform.position;
            this.GameObjectWrap.transform.rotation = transform.rotation;
            
        }

        public void Init()
        {
            this.actionControl = new ActionControl();
            this.actionControl.Init(this);
        }

        public void Update()
        {
            if (this.actionControl != null)
            {
                this.actionControl.Update();
            }
            
        }
    }
}