using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private int _penetr;

    private float _fast;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int penetr, Vector3 dir)
    {
        this.damage = damage;
        _penetr = penetr;
        _fast = 15f;

        if ( _penetr >= 0 )
        {
            _rb.velocity = dir * _fast;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) { return; }
        _penetr--;

        if (_penetr < 0)
        {
            _rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
