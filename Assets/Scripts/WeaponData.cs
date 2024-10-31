using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Scriptable Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType { Bullet }

    [Header("# Info")]
    public WeaponType weaponType;
    public int weaponId;
    public string weaponName;
    public GameObject projectile; // for prefabs

    [TextArea]
    public string weaponDesc;
    public Sprite weaponIcon;

    [Header("# Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;
}
