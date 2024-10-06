using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPRange : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position;
        }
    }
    
}
