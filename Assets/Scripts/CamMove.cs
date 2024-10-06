using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private float _smoothSpeed = 0.125f;
    void Start()
    {
        transform.position = _player.position + _offset;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        
        // 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}   
