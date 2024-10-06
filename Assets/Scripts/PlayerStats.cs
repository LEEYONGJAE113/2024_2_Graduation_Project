using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float _playerHP;
    private float _playerEXP = 0f;
    private int _playerLevel = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EXPMarble")
        {
            EXPMarble expmarble = other.gameObject.GetComponent<EXPMarble>();
            Destroy(other.gameObject);
            _playerEXP += expmarble.Exp;
        }
    }
}
