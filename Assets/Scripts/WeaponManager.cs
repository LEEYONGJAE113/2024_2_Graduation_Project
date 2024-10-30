using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int id;
    public int prefabsId;
    public float damage;

    public Player player;


    void Awake()
    {
        player = GameManager.instance.player;
    }

    public void Init()
    {
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;
    }

    void FireBullet()
    {
        if (!player.scanner.nearestTarget) { return; }

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        // Get(temp), need item data-prefabId
        Transform bullet = GameManager.instance.pool.Get(1).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        // need getcomponent
    }

}
