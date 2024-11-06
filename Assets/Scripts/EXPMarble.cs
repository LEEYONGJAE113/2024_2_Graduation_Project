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
    private Rigidbody2D _player;
    private bool _isLive;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriter = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        _player = GameManager.instance.player.GetComponent<Rigidbody2D>();
        _isLive = true;
    }
    public void Init()
    {
        _exp = Mathf.FloorToInt(GameManager.instance.currentGameTime / 100f) + 1.5f;
    }

    public void GoToPlayer()
    {
        if (!GameManager.instance.isTimeGoing) { return; }

    }
}
