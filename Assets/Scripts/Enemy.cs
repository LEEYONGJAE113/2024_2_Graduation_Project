using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _expMarble;

    [SerializeField]
    private float _hp = 1f;

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            _hp -= weapon.Damage;
            if(_hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(_expMarble, transform.position, Quaternion.identity);
            }
        }
    }
}
