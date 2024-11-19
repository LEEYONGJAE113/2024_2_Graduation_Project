using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum Quests { Kill, Box, Move, Survive };
    public Quests currentQuest;
    private Quests[] _questList;

    void Awake()
    {
        _questList = (Quests[])Enum.GetValues(typeof(Quests));
    }
    void GetQuest(int level)
    {
        int randomIndex = UnityEngine.Random.Range(0, _questList.Length);
        currentQuest = _questList[randomIndex];

        switch (currentQuest)
        {
            case Quests.Kill:
                int currentKills = GameManager.instance.inGameKill;
                
                break;
            case Quests.Box:
                break;
            case Quests.Move:
                break;
            case Quests.Survive:
                break;
        }

    }

}
