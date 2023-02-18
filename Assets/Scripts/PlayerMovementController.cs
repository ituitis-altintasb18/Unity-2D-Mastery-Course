using System;
using UnityEngine;
[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] 
    private float moveSpeed = 10;
    [SerializeField]
    private float jumpForce = 400;
    [SerializeField]
    private float bounceForce = 300;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;

    public float Speed { get; private set; }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && characterGrounding.IsGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;

        

    }

    internal void Bounce()
    {
        rigidbody2D.AddForce(Vector2.up * bounceForce);
    }
}
