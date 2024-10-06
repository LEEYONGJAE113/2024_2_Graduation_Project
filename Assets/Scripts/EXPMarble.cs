using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPMarble : MonoBehaviour
{
    private Transform _expRange;
    private Rigidbody2D _rb;
    private float _MoveSpeed = 20f;
    private bool _isFollowing = false;

    [SerializeField]
    private float _exp = 1f;

    public float Exp { get; private set; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Exp = _exp; // 초기화
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPRange")
        {
            _expRange = other.transform; // 추적할 대상 설정
            _isFollowing = true; // 추적 시작
        }
    }

    private void Update()
    {
        if (_isFollowing && _expRange != null)
        {
            Vector3 direction = (_expRange.position - transform.position).normalized;
            _rb.MovePosition(transform.position + direction * _MoveSpeed * Time.deltaTime);
            
            // 목표에 도달했는지 확인
            if (Vector3.Distance(transform.position, _expRange.position) < 0.1f)
            {
                _isFollowing = false; // 목표에 도달하면 추적 중지
            }
        }
    }

    

    
}
