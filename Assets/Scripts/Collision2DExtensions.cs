using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D collision)           //checks if the contact is a player
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    public static bool WasHitFromBottomSide(this Collision2D collision)     //checking the contact location of the CoinBox
    {
        return collision.contacts[0].normal.y > 0.5;
    }
    public static bool WasHitFromUpperSide(this Collision2D collision)     //checking the contact location of the CoinBox
    {
        return collision.contacts[0].normal.y < -0.5;
    }
}
