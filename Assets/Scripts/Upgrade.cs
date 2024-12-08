using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private RectTransform _rect;
    private Item[] _items;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _items = GetComponentsInChildren<Item>(true);
    }

    public void Show()
    {
        Next();
        _rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        _rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index)
    {
        _items[index].OnClick();
    }

    void Next()
    {
        foreach(Item item in _items)
        {
            item.gameObject.SetActive(false);
        }

        int[] ran = new int[3];
        while(true)
        {
            ran[0] = Random.Range(0, _items.Length);
            ran[1] = Random.Range(0, _items.Length);
            ran[2] = Random.Range(0, _items.Length);

            if(ran[0]!=ran[1] && ran[1]!=ran[2] && ran[0]!=ran[2]) { break; }
        }
        
        for (int index = 0; index < ran.Length; index++)
        {
            Item ranItem = _items[ran[index]];
            if (ranItem.weaponlevel == ranItem.data.damages.Length)
            {
                _items[0/*need gold or something*/].gameObject.SetActive(true);
            }
            else
            {
                ranItem.gameObject.SetActive(true);
            }
        }
    }
}
