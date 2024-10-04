using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject expMarble;
    private float hp = 1f;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if(hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(expMarble, transform.position, Quaternion.identity);
            }
        }
    }
}
