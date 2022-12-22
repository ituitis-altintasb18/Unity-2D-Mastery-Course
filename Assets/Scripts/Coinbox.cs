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
        if (remainingCoins > 0 &&                                       //checks if there is still coin in the Coinbox
            WasHitByPlayer(collision) &&          
            WasHitFromBottomSide(collision))                                           
        {

            GameManager.Instance.AddCoin();
            remainingCoins--;
            if (remainingCoins <= 0)
            {
                enabledSprite.enabled = false;
                disabledSprite.enabled = true;
            }


        }
    }

    private static bool WasHitByPlayer(Collision2D collision)           //checks if the contact is a player
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    private static bool WasHitFromBottomSide(Collision2D collision)     //checking the contact location of the CoinBox
    {
        return collision.contacts[0].normal.y > 0.5;
    }
}
