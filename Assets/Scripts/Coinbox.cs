using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer enabledSprite;
    [SerializeField]
    private SpriteRenderer disabledSprite;
    [SerializeField]
    private int totalCoins = 1;

    private int remainingCoins;
    // Start is called before the first frame update
    void Awake()
    {
        remainingCoins = totalCoins;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(remainingCoins > 0 &&
            collision.collider.GetComponent<PlayerMovementController>() != null)
        {
            Debug.Log(collision.contacts[0].normal);
            GameManager.Instance.AddCoin();
            remainingCoins--;
            if(remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;
            }
        }
    }
}
