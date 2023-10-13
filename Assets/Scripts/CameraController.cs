using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public Transform pivot;
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 2.0f; // Add a zoom speed parameter
    public float minZoomDistance = 1.0f; // Minimum zoom distance
    public float maxZoomDistance = 10.0f; // Maximum zoom distance

    private Vector3 lastMousePosition;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - lastMousePosition;

            transform.RotateAround(pivot.position, Vector3.up, delta.x * rotationSpeed);
            transform.RotateAround(pivot.position, transform.right, -delta.y * rotationSpeed);

            lastMousePosition = Input.mousePosition;
        }

        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        
        var zoomDirection = zoomInput * zoomSpeed * transform.forward;
        var newPosition = transform.position + zoomDirection;

        newPosition = Vector3.ClampMagnitude(newPosition - pivot.position, maxZoomDistance) + pivot.position;
        newPosition = Vector3.ClampMagnitude(newPosition - pivot.position, maxZoomDistance) + pivot.position;

        transform.position = newPosition;
    }
}

