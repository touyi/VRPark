using UnityEngine;

namespace DefaultNamespace
{
    public interface IActor
    {
        GameObject GameObjectWrap { get; }
        void TPPosition(Vector3 worldPosition);
        void TPPosition(Transform transform);
        void Init();
        void Update();

    }
}