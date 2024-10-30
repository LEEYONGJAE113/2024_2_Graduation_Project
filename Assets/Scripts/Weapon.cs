using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private int _prefabsId;
    public float damage;

    private Player _player;


    void Awake()
    {
        _player = GameManager.instance.player;
    }

    public void Init()
    {
        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;
    }

    void FireBullet()
    {
        if (!_player.scanner.nearestTarget) { return; }

        Vector3 targetPos = _player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        // Get(temp), need item data-prefabId
        Transform bullet = GameManager.instance.pool.Get(1).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        // need getcomponent
    }

}
