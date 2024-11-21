using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool playerLive;
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
        Vector2 nextPos = _rb.position + nextVec;
        if (GameManager.instance.questManager.currentQuest == QuestManager.Quests.Move)
        {
            float distance = Vector2.Distance(_rb.position, nextPos);
            GameManager.instance.questManager.questProgress += distance;
        }
        _rb.MovePosition(nextPos);
        _rb.velocity = Vector2.zero;
    }

    void OnMove(InputValue inputValue)
    {
        _inputVec = inputValue.Get<Vector2>();
    }


}
