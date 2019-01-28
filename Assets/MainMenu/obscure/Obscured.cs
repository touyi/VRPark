using UnityEngine;


public class Obscured : MonoBehaviour
{
    public Material stoppedMaterial;

    void Update()
    {
        // get all renderers in this object and its children:
        Renderer[] renderers = GetComponentsInChildren<Renderer>(true);

        foreach (Renderer r in renderers)
        {
            if(!r.material.Equals(stoppedMaterial))
            {
                r.material.renderQueue = 2002; // set their renderQueue
            }
        }
    }
}
