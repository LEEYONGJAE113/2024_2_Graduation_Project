using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 2f;
    
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 가로
        float verticalInput = Input.GetAxisRaw("Vertical"); // 세로

        Vector2 moveTo = new Vector2(horizontalInput, verticalInput);

        if(moveTo != Vector2.zero)
        {
            moveTo.Normalize();
        }

        // transform.position += moveTo * moveSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + moveTo * _moveSpeed * Time.deltaTime);
    }

    
}
