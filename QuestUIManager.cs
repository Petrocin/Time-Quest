//визуализация квестов
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestUIManager : MonoBehaviour
{
    public QuestManager questManager; 
    public GameObject questItemPrefab; 
    public Transform content; 

    void Start()
    {
        if (questManager == null)
        {
            questManager = FindObjectOfType<QuestManager>();
        }

        UpdateQuestList();
    }

    public void UpdateQuestList()
    {

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

 
        foreach (var quest in questManager.quests)
        {
            GameObject questItem = Instantiate(questItemPrefab, content);
            Text questText = questItem.GetComponent<Text>();
            questText.text = $"{quest.questName} - {quest.currentAmount}/{quest.targetAmount} {(quest.isCompleted ? "(Çàâåðøåí)" : "")}";
        }
    }
}
