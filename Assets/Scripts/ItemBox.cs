using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    private DropItemData[] _datas;
    private DropItemData _selectedItem;
    

    public void Init()
    {
        _selectedItem = _datas[Random.Range(0, _datas.Length)];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            GameObject dropItem = GameManager.instance.pool.Get(2, _selectedItem.dropItemId);
            dropItem.transform.position = transform.position;
            dropItem.GetComponent<DropItems>().Init(_selectedItem);
            dropItem.transform.SetParent(null);

            gameObject.SetActive(false);
        }
    }

}   