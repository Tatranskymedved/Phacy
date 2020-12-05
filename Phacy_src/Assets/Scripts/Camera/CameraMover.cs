using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public InputReader _inputReader;
    public Camera mainCamera;

    private void OnEnable()
    {
        if (mainCamera == null) //If camera wasn't assigned in Inspector, try to find it
            mainCamera = this.GetComponentInParent<Camera>();

        _inputReader.cameraMoveEvent += OnCameraMove;
    }

    private void OnDisable()
    {
        _inputReader.cameraMoveEvent -= OnCameraMove;
    }

    private void OnCameraMove(Vector2 transform)
    {
        //TODO: check if camera moves correctly & improve
        if (mainCamera != null)
            mainCamera.transform.position = transform;
    }
}
