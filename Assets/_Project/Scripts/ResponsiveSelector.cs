using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveSelector : MonoBehaviour, ISelector
{
    private Transform _selection;

    [SerializeField] private List<Transform> selectables;
    [SerializeField] private float threshold = 0.98f;

    public void Check(Ray ray)
    {
        _selection = null;
        var _closestSelectablePercentage = 0f;
        foreach (var sel in selectables)
        {
            var v1 = ray.direction;
            var v2 = sel.transform.position - ray.origin;

            // selectables[i].

            var lookPercentage = Vector3.Dot(v1.normalized, v2.normalized);
            if (lookPercentage > threshold && lookPercentage > _closestSelectablePercentage)
            {
                _closestSelectablePercentage = lookPercentage;
                _selection = sel.transform;
            }
        }
    }

    public Transform GetSelection() => _selection;
}