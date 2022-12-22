using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += Pulse;
    }

    private void Pulse(int coins)
    {
        animator.SetTrigger("Pulse");
    }
}
