using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    public float enemyMoveSpeed = 5f;
    
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            // float distance = Vector3.Distance(transform.position, player.position);

            rb.MovePosition(transform.position + direction * enemyMoveSpeed * Time.fixedDeltaTime);
        }
    }
}
