using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    /// <summary> <item> <description> 
    /// 0 = 원거리추적무기, 1 = 드롭아이템메테오, 2 = 가비지트럭 
    /// </description> </item> </summary>
    [SerializeField]
    private int _id;
    public float damage;
    [SerializeField]
    private int _count; // penetr in bullet(0)
    [SerializeField]
    private float _cooldown;
    private float _timer;
    private Player _player;


    void Awake()
    {
        _player = GameManager.instance.player;
    }

    public void Init(WeaponData data)
    {
        name = "Weapon " + data.weaponId + " : " + data.weaponName; //object name

        transform.parent = _player.transform;
        transform.localPosition = Vector3.zero;

        PropertySet(data);
    }
    
    void PropertySet(WeaponData data)
    {
        _id = data.weaponId;
        damage = data.baseDamage;
        _count = data.baseCount;
        _cooldown = data.baseCooldown;
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        _count += count;
    }


    void Update()
    {
        _timer += Time.deltaTime;
        switch(_id)
        {
            case 0:
                if (_timer > _cooldown)
                {
                    _timer = 0f;
                    FireBullet();
                }
                break;
        }
        
    }


    void FireBullet()
    {
        if (!_player.scanner.nearestTarget) { return; }

        Vector3 targetPos = _player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(1, _id).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.right, dir);
        bullet.GetComponent<Bullet>().Init(damage, _count, dir);
    }

    void CallTruck()
    {
        Transform truck = GameManager.instance.pool.Get(1, _id).transform;
        Vector3 playerPos = _player.transform.position;
        float truckX = playerPos.x + UnityEngine.Random.Range(-50, 50);
        float truckY = playerPos.y + UnityEngine.Random.Range(-50, 50);
        
        Vector3 dir = playerPos - transform.position;
        dir = dir.normalized;
        
        truck.position = new Vector3(truckX, truckY, playerPos.z);
        truck.rotation = Quaternion.FromToRotation(Vector3.right, dir);
        truck.GetComponent<GCTruck>().Init(damage, _count, dir);
    }

}