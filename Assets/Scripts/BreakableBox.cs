using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(WasHitByPlayer(collision) &&
            WasHitFromBottomSide(collision))
        {
            Destroy(gameObject);
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