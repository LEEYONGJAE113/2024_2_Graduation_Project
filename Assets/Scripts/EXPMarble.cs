using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPMarble : MonoBehaviour
{
    public Transform expRange;
    private Rigidbody2D rb;
    public float expMoveSpeed = 20f;
    private bool isFollowing = false;

    public float marbleEXP = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPRange")
        {
            expRange = other.transform; // 추적할 대상 설정
            isFollowing = true; // 추적 시작
        }
    }

    private void Update()
    {
        if (isFollowing && expRange != null)
        {
            Vector3 direction = (expRange.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * expMoveSpeed * Time.deltaTime);
            
            // 목표에 도달했는지 확인
            if (Vector3.Distance(transform.position, expRange.position) < 0.1f)
            {
                isFollowing = false; // 목표에 도달하면 추적 중지
            }
        }
    }

    

    
}
