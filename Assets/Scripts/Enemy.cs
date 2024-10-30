using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private bool _isLive;
    [SerializeField]
    private float _currentHp;
    [SerializeField]
    private float _maxHp;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Rigidbody2D _player;
    
    private Animator _anim;
    private Collider2D _coll;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriter;
    private WaitForFixedUpdate _wait;

    // private GameObject[] _expMarbles;
    private GameObject _expMarble;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
        _anim = GetComponent<Animator>();
        _spriter = GetComponent<SpriteRenderer>();
        _wait = new WaitForFixedUpdate();
    }

    void OnEnable()
    {
        _player = GameManager.instance.player.GetComponent<Rigidbody2D>();
        _isLive = true;
        _coll.enabled = true;
        _rb.simulated = true;
        _spriter.sortingOrder = 2;
        _currentHp = _maxHp;
    }

    void FixedUpdate()
    {
        if (!_isLive || _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) { return; }
        Vector2 dir = _player.position - _rb.position;
        Vector2 nextVec = dir.normalized * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + nextVec);
        _rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!_isLive) { return; }
        _spriter.flipX = (_player.position.x < _rb.position.x);
    }

    public void Init()
    {
        // temp, need data
        _moveSpeed = 3f;
        _maxHp = 5f;
        _currentHp = 5f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon") || !_isLive) { return; }

        _currentHp -= collision.GetComponent<WeaponManager>().damage;
        StartCoroutine(Knockback());

        if ( _currentHp > 0 )
        {
            _anim.SetTrigger("Hit");
        }
        else
        {
            Die(); // 나중에 animation controll로 제어
            GameManager.instance.kill++;
            // DropExp();
        }
    }

    void Die()
    {
        _isLive = false;
        _coll.enabled = false;
        _rb.simulated = false;
        _spriter.sortingOrder = 1;
        gameObject.SetActive(false);
    }

    IEnumerator Knockback()
    {
        yield return new WaitForFixedUpdate();
        if (!_isLive) { yield break; }
        Vector3 dir = transform.position - _player.transform.position;
        _rb.AddForce(dir.normalized * 3f, ForceMode2D.Impulse);
    }

    // void DropExp()
    // {
    //     _expMarble.GetComponent<EXPMarble>().Init();
    // }
}
