using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCTruck : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private int _count;
    private float _fast;
    private float _deleteTimer;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _deleteTimer += Time.deltaTime;
        if (_deleteTimer >= 10f)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init(float damage, int count, Vector3 dir)
    {
        this.damage = damage;
        _count = count;
        _fast = 10f;

        _rb.velocity = dir * _fast;
    }
}
