using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private LayerMask layerMask;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;    //question mark makes this either a vector or a null

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    private void Update()
    {
        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
                break;
        }
        
        StickToMovingObjects();
    }


    private void StickToMovingObjects()
    {
        if (groundedObject != null)
        {
            if (groundedObjectLastPosition.HasValue && //in here we check if it has value cause it is a vector3 with question mark (Vector3?)
               groundedObjectLastPosition.Value != groundedObject.position) //checks if the difference between the last position is not zero. Most of the time since we are not on it is zero
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value; //calculating the difference since last fram
                transform.position += delta;    //adding to player position
            }
            groundedObjectLastPosition = groundedObject.position;   //inital set for groundedObjectLastPosition
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        Debug.DrawRay(foot.position, foot.forward * maxDistance, Color.red);
        if (raycastHit.collider != null)
        {
            if (groundedObject != raycastHit.collider.transform)
            {
                groundedObjectLastPosition = raycastHit.collider.transform.position;
            }
            groundedObject = raycastHit.collider.transform; //groundedObject is set here first
            IsGrounded = true;
            GroundedDirection = foot.forward;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }
}
