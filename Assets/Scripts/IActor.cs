using UnityEngine;

namespace DefaultNamespace
{
    public interface IActor
    {
        IActionControl ActionControl { get; }
        GameObject GameObjectWrap { get; }
        void TPPosition(Vector3 worldPosition);
        void TPPosition(Transform transform);
        void Init();
        void Update();

    }
}