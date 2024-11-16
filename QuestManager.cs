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
            new Quest { questName = "Собери монеты", description = "Собери 5 монет.", targetAmount = 5, currentAmount = 0, isCompleted = false }
            //                                                      ^
            // тут способом аналогично добавлять кветы по алгоритму:|
        };
    }

    public void CollectCoin()
    {

        foreach (var quest in quests)
        {
            if (!quest.isCompleted && quest.currentAmount < quest.targetAmount)
            {
                quest.currentAmount++;
                Debug.Log($"Собрано монет: {quest.currentAmount}/{quest.targetAmount} для квеста: {quest.questName}");

                if (quest.currentAmount >= quest.targetAmount)
                {
                    quest.isCompleted = true;
                    Debug.Log($"Квест завершен: {quest.questName}");
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
