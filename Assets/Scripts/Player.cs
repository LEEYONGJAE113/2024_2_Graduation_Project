using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _inputVec;
    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = _inputVec * GameManager.instance.playerMoveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + nextVec);
    }

    void OnMove(InputValue inputValue)
    {
        _inputVec = inputValue.Get<Vector2>();
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "EXPMarble")
    //     {
    //         EXPMarble expmarble = other.gameObject.GetComponent<EXPMarble>();
    //         Destroy(other.gameObject);
    //         _playerEXP += expmarble.Exp;
    //     }
    // }

}