using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance { get; private set; } // создал статический экземпляр класса
    [SerializeField] private TextMeshProUGUI coinText; 
    private int coinCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void CollectCoin()
    {
        coinCount++;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = $"Coins: {coinCount}"; // сделал интерполяция строк для удобства чтения
    }
}
