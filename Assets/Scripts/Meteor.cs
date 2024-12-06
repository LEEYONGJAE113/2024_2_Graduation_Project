using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private float _radius;
    private CircleCollider2D _collider;
    
    void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    public void Init(float damage)
    {
        this.damage = damage;
        transform.localScale = new Vector3(_radius, _radius, 1);
        _collider.radius = _radius;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) { return; }
        GameManager.instance.inGameCurrentHp += GameManager.instance.playerMaxHP / 10;
    }

}
