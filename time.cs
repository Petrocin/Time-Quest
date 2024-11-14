using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NewBehaviourScript : MonoBehaviour
{
    private float Timecount = 0f;
    public TextMeshProUGUI timeText;

    private void Update() {
        Timecount += Time.deltaTime;
        UpdateTimeUI();

    }
    private void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(Timecount / 60);
        int seconds = Mathf.FloorToInt(Timecount % 60);
        if (timeText != null)
        {



            timeText.text = string.Format( "time:    "+"{0:00} : {1:00}", minutes, seconds);
        }
    }
}
