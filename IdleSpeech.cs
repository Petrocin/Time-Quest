using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IdleSpeech : MonoBehaviour
{
    public GameObject dialogueBox; 
    public Text dialogueText; 
    public AudioClip dialogueSound; 
    public float minIdleTime = 3f; 
    public float maxIdleTime = 7f;
    private bool isDialogueActive = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(CheckIdleTime());
    }

    private IEnumerator CheckIdleTime()
    {
        while (true)
        {
            float randomIdleTime = Random.Range(minIdleTime, maxIdleTime);
            yield return new WaitForSeconds(randomIdleTime);
            if (!isDialogueActive)
            {
                ShowRandomSymbols();
            }
        }
    }

    private void ShowRandomSymbols()
    {
        isDialogueActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = GenerateRandomSymbols(6);
        audioSource.PlayOneShot(dialogueSound);

        StartCoroutine(HideDialogueAfterTime(2f)); 
    }

    private IEnumerator HideDialogueAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueBox.SetActive(false);
        isDialogueActive = false;
    }

    private string GenerateRandomSymbols(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-+=[]{}|;:'\",.<>?/"; 
        char[] randomChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            randomChars[i] = chars[Random.Range(0, chars.Length)];
        }
        return new string(randomChars);
    }
}