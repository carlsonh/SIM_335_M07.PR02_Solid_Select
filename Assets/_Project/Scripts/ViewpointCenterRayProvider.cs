using UnityEngine;

public class ViewpointCenterRayProvider : MonoBehaviour, IRayProvider
{
    public Ray CreateRay()
    {
        return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
    }
}