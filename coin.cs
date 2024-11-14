using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;
  
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.Play();
        audioSource.clip = collectSound;
      
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayCollectSound();
            audioSource.Play();
            CoinCounter.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }

    void PlayCollectSound()
    {
        Debug.Log("Playing collect sound.");
        audioSource.Play();
        audioSource.PlayOneShot(collectSound);
        audioSource.volume = 1.0f;
        Debug.Log("Played sound: " + collectSound.name);
    }
}





