using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private int _penetr;
    [SerializeField]

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int penetr, Vector3 dir)
    {
        this._damage = damage;
        this._penetr = penetr;

        if ( _penetr >= 0 )
        {
            _rb.velocity = dir * 15f;
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
