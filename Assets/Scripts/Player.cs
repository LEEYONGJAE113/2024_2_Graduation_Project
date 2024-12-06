using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool playerLive;
    public bool superMode;
    private float _superTime;
    private Vector2 _inputVec;
    private Rigidbody2D _rb;
    public Scanner scanner;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        scanner = GetComponent<Scanner>();
    }

    void Update()
    {
        if (!superMode || !GameManager.instance.isTimeGoing) { return; }
        _superTime -= Time.deltaTime;
        if (_superTime <= 0)
        {
            superMode = false;
        }
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

    // void OnCollisionStay2D(Collision2D collision)
    // {
    //     if (!GameManager.instance.isLive || superMode) { return; }

    //     GameManager.instance.health -= Time.deltaTime * 10;

    //     if (GameManager.instance.health < 0)
    //     {
    //         for (int index = 2; index < transform.childCount; index++)
    //         {
    //             transform.GetChild(index).gameObject.SetActive(false);
    //         }

    //         anim.SetTrigger("Dead");
    //         GameManager.instance.GameOver();
    //     }
    // }

    public void StartSuperMode(float time)
    {
        _superTime = time;
        superMode = true;
    }


}
