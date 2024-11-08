using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _currentHp;
    [SerializeField]
    private float _maxHp;
    [SerializeField]
    private float _moveSpeed;
    public RuntimeAnimatorController[] animCon;
    [SerializeField]
    private Rigidbody2D _player;

    private bool _isLive;
    private Animator _anim;
    private Collider2D _collider;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriter;
    private WaitForFixedUpdate _wait;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
        _spriter = GetComponent<SpriteRenderer>();
        _wait = new WaitForFixedUpdate();
    }

    void OnEnable()
    {
        _player = GameManager.instance.player.GetComponent<Rigidbody2D>();
        _isLive = true;
        _collider.enabled = true;
        _rb.simulated = true;
        _spriter.sortingOrder = 2;
        _anim.SetBool("Dead", false);
        _currentHp = _maxHp;
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isTimeGoing) { return; }
        if (!_isLive || _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) { return; }
        Vector2 dir = _player.position - _rb.position;
        Vector2 nextVec = dir.normalized * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + nextVec);
        _rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isTimeGoing) { return; }
        if (!_isLive) { return; }
        _spriter.flipX = (_player.position.x < _rb.position.x);
    }

    public void Init(EnemyData data)
    {
        _anim.runtimeAnimatorController = animCon[data.enemyType];
        _moveSpeed = data.enemyMoveSpeed;
        _maxHp = data.enemyHealth;
        _currentHp = data.enemyHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon") || !_isLive) { return; }

        _currentHp -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(Knockback());

        if ( _currentHp > 0 )
        {
            _anim.SetTrigger("Hit");
        }
        else
        {
            Die();
            GameManager.instance.inGameKill++;
        }
    }

    void Die()
    {
        _isLive = false;
        _collider.enabled = false;
        _rb.simulated = false;
        _spriter.sortingOrder = 1;
        _anim.SetBool("Dead", true);
    }

    IEnumerator Knockback()
    {
        if (!_isLive) { yield break; }
        yield return _wait;
        Vector3 dir = transform.position - GameManager.instance.player.transform.position;
        _rb.AddForce(dir.normalized * 1.1f, ForceMode2D.Impulse);
    }
    
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
