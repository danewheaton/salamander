using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;

    Rigidbody2D myRigidbody;
    Vector2 input;

    private void Start()
    {
        myRigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        myRigidbody.MovePosition((Vector2)myRigidbody.transform.position + input * speed);
    }
}
