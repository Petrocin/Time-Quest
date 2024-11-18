using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound; // Задайте эту переменную в инспекторе Unity
    [SerializeField] private AudioClip coinSound; // Задайте эту переменную в инспекторе Unity
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collectSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        PlayCollectSound();
        CoinCounter.Instance.CollectCoin();
        Destroy(gameObject);
    }

    private void PlayCollectSound()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }
}
