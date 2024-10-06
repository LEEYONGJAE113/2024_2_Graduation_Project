using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _damage = 1f;

    public float Damage { get; private set; }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Awake()
    {
        Damage = _damage; // 초기화
    }
}
