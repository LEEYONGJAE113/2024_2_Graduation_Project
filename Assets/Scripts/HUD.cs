using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Quest, Level, Kill, Gold, Time, HP, Equipment }
    public InfoType type;

    private Text _text;
    private Slider _slider;

    void Awake()
    {
        _text = GetComponent<Text>();
        _slider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Quest:
                break;
            case InfoType.Level:
                break;
            case InfoType.Kill:
                _text.text = string.Format("{0:F0}", GameManager.instance.inGameKill);
                break;
            case InfoType.Gold:
                break;
            case InfoType.Time:
                break;
            case InfoType.HP:
                break;
            case InfoType.Equipment:
                break;
        }
    }
}
