using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour, ITakeShellHits
{
    [SerializeField]
    private SpriteRenderer enabledSprite;
    [SerializeField]
    private SpriteRenderer disabledSprite;
    [SerializeField]
    private int totalCoins = 1;

    private Animator animator;
    private int remainingCoins;

    public void HandleShellHit(ShellUpside shellUpside)
    {
        if(remainingCoins > 0)
            TakeCoin();
    }

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        remainingCoins = totalCoins;       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 &&                                       //checks if there is still coin in the Coinbox
            collision.WasHitByPlayer() &&          
            collision.WasHitFromBottomSide())
        {
            TakeCoin();

        }
    }

    private void TakeCoin()
    {
        GameManager.Instance.AddCoin();
        remainingCoins--;
        animator.SetTrigger("FlipCoin");

        if (remainingCoins <= 0)
        {
            enabledSprite.enabled = false;
            disabledSprite.enabled = true;
        }
    }
}
