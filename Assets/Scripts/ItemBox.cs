using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private DropItemData[] _datas;
    private bool _isBox;
    private Collider2D _collider;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }


    void OnEnable()
    {
        _isBox = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && _isBox)
        {
            _isBox = false;
        }
        if (collision.CompareTag("Player") && !_isBox)
        {
            Debug.Log("Wow");
        }
    }

}   