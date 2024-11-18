using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    [SerializeField] private TextMeshProUGUI timeText; 

    private void Update()
    {
        UpdateElapsedTime();
        UpdateTimeUI();
    }

    private void UpdateElapsedTime()
    {
        elapsedTime += Time.deltaTime;
    }

    private void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        if (timeText != null)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
