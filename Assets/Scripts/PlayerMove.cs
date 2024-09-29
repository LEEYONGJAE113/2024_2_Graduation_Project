using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 가로
        float verticalInput = Input.GetAxisRaw("Vertical"); // 세로

        Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);

        if(moveTo != Vector3.zero)
        {
            moveTo.Normalize();
        }

        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Wall"))
    //     {
    //         transform.position = Vector3.zero;
    //     }
    // }
}
