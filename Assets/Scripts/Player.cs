using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool _isLive;
    private Vector2 _inputVec;
    private Rigidbody2D _rb;
    public Scanner scanner;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = _inputVec * GameManager.instance.playerMoveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + nextVec);
        _rb.velocity = Vector2.zero;
    }

    void OnMove(InputValue inputValue)
    {
        _inputVec = inputValue.Get<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("EXPMarble")) { return; }
        
    }

}
