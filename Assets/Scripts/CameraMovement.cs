using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField, Range(1, 10)] float speed = 5;
    [SerializeField] Vector2 offset = Vector2.zero;

    Camera cam;

    Vector3 targetPos;

    float speedModifier = 10;

    private void Start()
    {
        if (!player)
        {
            player = transform;
        }

        targetPos = player.position;

        CenterOnPlayer();

        Camera camComponent = GetComponent<Camera>();

        if (camComponent)
        {
            cam = camComponent;
        }
    }

    private void FixedUpdate()
    {
        targetPos = Vector3.MoveTowards(targetPos, (Vector2)player.position + offset, speed * speedModifier * Time.deltaTime);
        targetPos.z = transform.position.z;

        transform.position = targetPos;
    }

    public void CenterOnPlayer()
    {
        if (player)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    public void ChangeZoom(float newZoom)
    {
        cam.orthographicSize = newZoom;
    }

    public float GetZoom()
    {
        return cam.orthographicSize;
    }
}
