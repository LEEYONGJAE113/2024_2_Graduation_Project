using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_HomingMissile : MonoBehaviour
{
    [SerializeField]
    private float _MoveSpeed = 10f;
    [SerializeField]
    private float _rotationSpeed = 200f;
    public float damage;

    private Vector3 _moveDirection;
    private Rigidbody2D _rb;
    private Transform _target;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        FindTarget();
        InitializeDirection();
    }

    void Update()
    {
        transform.Translate(_moveDirection * _MoveSpeed * Time.deltaTime, Space.World);
    }

    void InitializeDirection()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            _moveDirection = direction;
        }
        else
        {
            _moveDirection = Vector3.right;
        }
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Enemy Tag인 오브젝트 모두 배열에 저장
        float shortestDistance = Mathf.Infinity;
        // 현재까지 발견된 가장 가까운 적과의 거리 저장, 무한대로 초기화
        GameObject closestEnemy = null;

        foreach (GameObject Enemy in enemies) // 모든 enemies 배열에 대해 반복
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            // 현재 미사일 위치와 적 위치 사이의 거리 계산
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = Enemy;
                // 제일 가까운 적을 현재 Enemy로 설정
            }
        }

        if (closestEnemy != null)
        {
            _target = closestEnemy.transform;
        }
    }
}
