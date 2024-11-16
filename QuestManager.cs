using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public int targetAmount;
    public int currentAmount;
    public bool isCompleted;
}

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;

    void Start()
    {
        quests = new List<Quest>
        {
            new Quest { questName = "������ ������", description = "������ 5 �����.", targetAmount = 5, currentAmount = 0, isCompleted = false }
            //                                                      ^
            // ��� �������� ���������� ��������� ����� �� ���������:|
        };
    }

    public void CollectCoin()
    {

        foreach (var quest in quests)
        {
            if (!quest.isCompleted && quest.currentAmount < quest.targetAmount)
            {
                quest.currentAmount++;
                Debug.Log($"������� �����: {quest.currentAmount}/{quest.targetAmount} ��� ������: {quest.questName}");

                if (quest.currentAmount >= quest.targetAmount)
                {
                    quest.isCompleted = true;
                    Debug.Log($"����� ��������: {quest.questName}");
                }
            }
        }

        QuestUIManager uiManager = FindObjectOfType<QuestUIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateQuestList();
        }
    }
}
}
