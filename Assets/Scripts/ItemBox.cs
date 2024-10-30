using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Destroy(gameObject);
            // Instantiate(_items[index], transform.position, Quaternion.identity);
        }
    }
}   
