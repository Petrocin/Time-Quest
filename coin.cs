//сбор монет и озвучка

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    public AudioClip collectSound;
    private AudioSource audioSource;
    public AudioClip coinSound;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collectSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayCollectSound();
            CoinCounter.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }

    void PlayCollectSound()
    {
        Debug.Log("Playing collect sound.");
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
        Debug.Log("Played sound: " + collectSound.name);
    }
}

// поправил логику алгоритма
