using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum Quests { Kill, Move, Box, Survive };
    public Quests currentQuest;
    public float questProgress;
    public float questGoal;
    public Quests[] questList;
    
    void Awake()
    {
        questList = (Quests[])Enum.GetValues(typeof(Quests));
    }

    void Update()
    {
        if (questProgress >= questGoal && GameManager.instance.isTimeGoing)
        {
            GameManager.instance.LevelUp();
            questProgress = 0f;
        }
    }

    public void GetQuest(int level)
    {
        int randomIndex = UnityEngine.Random.Range(3, 4);
        // int randomIndex = UnityEngine.Random.Range(0, questList.Length);
        currentQuest = questList[randomIndex];

        switch (currentQuest)
        {
            case Quests.Kill:
                questGoal = level * 5;
                break;
            case Quests.Box:
                questGoal = level;
                break;
            case Quests.Move:
                questGoal = 20 + (level * Mathf.Sqrt(level));
                // playerMoveSpeed per second
                break;
            case Quests.Survive:
                questGoal = (level * 3) + 7;
                break;
        }
    }
}
