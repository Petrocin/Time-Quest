//управление квестами
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
            new Quest { questName = "Ñîáåðè ìîíåòû", description = "Ñîáåðè 5 ìîíåò.", targetAmount = 5, currentAmount = 0, isCompleted = false }
            //                                                      ^
            // òóò ñïîñîáîì àíàëîãè÷íî äîáàâëÿòü êâåòû ïî àëãîðèòìó:|
        };
    }

    public void CollectCoin()
    {

        foreach (var quest in quests)
        {
            if (!quest.isCompleted && quest.currentAmount < quest.targetAmount)
            {
                quest.currentAmount++;
                Debug.Log($"Ñîáðàíî ìîíåò: {quest.currentAmount}/{quest.targetAmount} äëÿ êâåñòà: {quest.questName}");

                if (quest.currentAmount >= quest.targetAmount)
                {
                    quest.isCompleted = true;
                    Debug.Log($"Êâåñò çàâåðøåí: {quest.questName}");
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
