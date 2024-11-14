using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;
    public TextMeshProUGUI coinText;
    private int coinCount = 0;
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    private void Start() {
        UpdateCoinText();
    }
    public void CollectCoin() {
        coinCount++;
        UpdateCoinText();
    }
    private void UpdateCoinText() {
        coinText.text = "coins: " + coinCount;
    }
}
