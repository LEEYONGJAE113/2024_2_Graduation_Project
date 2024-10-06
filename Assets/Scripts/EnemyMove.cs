using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float _MoveSpeed = 5f;
    
    private Transform _player;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (_player != null)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            // float distance = Vector3.Distance(transform.position, player.position);

            _rb.MovePosition(transform.position + direction * _MoveSpeed * Time.fixedDeltaTime);
        }
    }
}
