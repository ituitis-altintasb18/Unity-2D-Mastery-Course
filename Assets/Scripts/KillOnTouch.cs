using UnityEngine;
using UnityEngine.SceneManagement;


public class KillOnTouch : MonoBehaviour, ITakeShellHits
{
    public void HandleShellHit(ShellUpside shellUpside)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();
        if (playerMovementController != null)
        {
            GameManager.Instance.KillPlayer();
        }
    }

}

