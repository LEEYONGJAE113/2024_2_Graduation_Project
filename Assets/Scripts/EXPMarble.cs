using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPMarble : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    private SpriteRenderer _spriter;
    private Rigidbody2D _rb;
    private float _exp;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
    }
    public void Init()
    {
        _exp = Mathf.FloorToInt(GameManager.instance.currentGameTime / 100f) + 1.5f;
    }
}
