using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    private DropItemData _itemData;
    private Collider2D _collider;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    
    void OnEnable()
    {
        _collider.enabled = true;
    }
    public void Init(DropItemData data)
    {
        _itemData = data;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player") || !GameManager.instance.player.playerLive) { return; }
        ItemEffect();
        _collider.enabled = false;
        gameObject.SetActive(false);
    }

    void ItemEffect()
    {
        switch (_itemData.dropItemType)
        {
            case DropItemData.DropItemType.Heal:
                GameManager.instance.inGameCurrentHp += GameManager.instance.playerMaxHP / 3;
                break;
            case DropItemData.DropItemType.LevelUp:
                GameManager.instance.LevelUp();
                break;
            case DropItemData.DropItemType.SuperMode:
                GameManager.instance.player.StartSuperMode(8f); // temp
                break;
            case DropItemData.DropItemType.Meteor:
                Transform meteor = GameManager.instance.pool.Get(1, 1).transform;
                meteor.position = transform.position;
                meteor.GetComponent<Meteor>().Init(100);
                break;
            case DropItemData.DropItemType.Gold:
                GameManager.instance.inGameGold += 50; // temp
                break;
        }
    }
}
