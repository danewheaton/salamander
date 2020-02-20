using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [SerializeField] float newZoomLevel = 5;
    [SerializeField] CameraMovement cam;

    float originalZoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        originalZoom = cam.GetZoom();
        cam.ChangeZoom(newZoomLevel);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.ChangeZoom(originalZoom);
    }
}
