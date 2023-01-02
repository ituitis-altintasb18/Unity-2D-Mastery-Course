using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private GameObject spawnOnStompPrefab;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer sprite;

    private Vector2 direction = Vector2.left;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + speed * Time.fixedDeltaTime * direction);
    }
    private void LateUpdate()
    {
        if (ReachedEdge() || HitNotPlayer())
        {
            SwitchDirections();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitFromUpperSide() && collision.WasHitByPlayer())
        {
            if(spawnOnStompPrefab != null)
            {
                Instantiate(spawnOnStompPrefab, transform.position, transform.rotation);
            }
            HandleWalkerStomped();
        }
        else if (collision.WasHitByPlayer())
        {
            GameManager.Instance.KillPlayer();
        }
    }

    private void HandleWalkerStomped()
    {
        Destroy(gameObject);
    }

    private bool HitNotPlayer()
    {
        float x = GetForwardX();
        float y = transform.position.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, direction * 0.1f);

        var hit = Physics2D.Raycast(origin, direction, 0.1f);    //checks if its a null object
        
        if (hit.collider == null)   //these are no turn
            return false;
        if (hit.collider.GetComponent<PlayerMovementController>()) 
            return false;
        if (hit.collider.isTrigger)
            return false;
        return true;
    }

    private bool ReachedEdge()
    {
        float x = GetForwardX();
        float y = collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);

        Debug.DrawRay(origin, Vector2.down * 0.1f);

        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);    //checks if its a null object

        if (hit.collider == null)   //that means time to turn
            return true;

        return false;
    }

    private float GetForwardX()
    {
        float x = direction.x == -1 ? //checks which side of the collider to use
                    collider.bounds.min.x - 0.1f : //colliders x axis' most left side
                    collider.bounds.max.x + 0.1f;
        return x;
    }

    private void SwitchDirections()
    {
        direction *= -1;
        sprite.flipX = !sprite.flipX;
    }
}
