using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum movementTypes { Sidescroller, TopDown}

    [SerializeField] Rigidbody2D myRigidbody;

    [Space]

    [SerializeField, Range(1, 10)] float speed = 5;
    [SerializeField] movementTypes movementType = movementTypes.Sidescroller;

    Vector2 input;

    float speedModifier = 2;

    private void OnValidate()
    {
        if (!myRigidbody)
        {
            myRigidbody = GetComponentInChildren<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), movementType == movementTypes.TopDown ? Input.GetAxis("Vertical") : 0);

        if (movementType == movementTypes.TopDown)
        {
            myRigidbody.gravityScale = 0;
        }

        if (input != Vector2.zero)
        {
            myRigidbody.MovePosition((Vector2)myRigidbody.transform.position + input * speed * speedModifier * Time.deltaTime);
        }
    }
}
