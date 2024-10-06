using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPRange : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
    
}
