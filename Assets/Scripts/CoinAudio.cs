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
        GameManager.Instance.OnCoinsChanged += (coins) => audioSource.Play();
    }
}
