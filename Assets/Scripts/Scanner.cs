using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private float _scanRange;

    [SerializeField]
    private LayerMask _targetLayer;

    [SerializeField]
    private RaycastHit2D[] _targets;

    public Transform nearestTarget;

    void FixedUpdate()
    {
        _targets = Physics2D.CircleCastAll(transform.position, _scanRange, Vector2.zero, 0, _targetLayer);
        nearestTarget = GetNearest(); // out parameter more fast?
    }

    Transform GetNearest()
    {
        Transform result = null;
        float originFar = 10000;

        foreach (RaycastHit2D target in _targets)
        {
            Vector3 thisPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float currentFar = Vector3.Distance(thisPos, targetPos);

            if (currentFar < originFar)
            {
                originFar = currentFar;
                result = target.transform;
            }
        }

        return result;
    }
}
