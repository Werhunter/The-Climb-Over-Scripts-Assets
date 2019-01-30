using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private float CameraMovementSpeed = 0.008f;

    private void Update()
    {
        Camera.transform.Translate(Vector2.up * CameraMovementSpeed);
    }
}