using System;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {   //bu SATIRI hic anlamadim
        GameManager.Instance.OnCoinsChanged += PlayCoinAudio;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinAudio;
    }
    //bu coins girmesi ne oluyo yani bu methoda neden coin giriyoki ???
    private void PlayCoinAudio(int coins)
    {
        audioSource.Play();
    }
}
