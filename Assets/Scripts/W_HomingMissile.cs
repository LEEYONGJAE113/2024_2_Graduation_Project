using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_HomingMissile : Weapon
{
    [SerializeField]
    public float HomingMissileMoveSpeed = 10f;
    [SerializeField]
    public float rotationSpeed = 200f;

    private Vector3 moveDirection;
    private Rigidbody2D rb;
    private Transform target;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        FindTarget();
        InitializeDirection();
    }

    void Update()
    {
        transform.Translate(moveDirection * HomingMissileMoveSpeed * Time.deltaTime, Space.World);
    }

    void InitializeDirection()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            moveDirection = direction;
        }
        else
        {
            moveDirection = Vector3.right;
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
            target = closestEnemy.transform;
        }
    }
}
