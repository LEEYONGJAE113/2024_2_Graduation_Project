using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public WeaponData data;
    public int weaponlevel;
    public Weapon weapon;

    private Image _icon;
    private Text textLevel;
    private Text textName;
    private Text textDesc;

    void Awake()
    {
        _icon = GetComponentsInChildren<Image>()[1];
        _icon.sprite = data.weaponIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.weaponName;
    }

    void OnEnable()
    {
        textLevel.text = "Lv." + (weaponlevel+1);
        switch(data.weaponType)
        {
            case WeaponData.WeaponType.Bullet:
            case WeaponData.WeaponType.GCTruck:
                textDesc.text = string.Format(data.weaponDesc, data.damages[weaponlevel] * 100, data.counts[weaponlevel]);
                break;
            default:
                textDesc.text = string.Format(data.weaponDesc);
                break;                
        }
    }

    public void OnClick()
    {
        switch(data.weaponType)
        {
            case WeaponData.WeaponType.Bullet:
            case WeaponData.WeaponType.GCTruck:
                if (weaponlevel == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = data.baseCount;
                    // float nextCooldown = data.baseCooldown;

                    nextDamage += data.baseDamage * data.damages[weaponlevel];
                    nextCount += data.counts[weaponlevel];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                weaponlevel++;
                break;
        }
        if (weaponlevel == data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
