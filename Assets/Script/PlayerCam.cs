using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCam : MonoBehaviour
{
    [Header("CameraZoom")]
    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 20.0f;
    public float minFOV = 30f;
    public float maxFOV = 60f;

    [Header("CameraRotate")]
    public Transform playerTransform;
    public float rotationSpeed = 5.0f;
    public float maxVerticalAngle = 80f;

    private bool isRotating;
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       CameraZoom(); 
    }
    void CameraZoom(){

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float currentFOV = virtualCamera.m_Lens.FieldOfView;

        currentFOV -= scrollInput * zoomSpeed;

        currentFOV = Mathf.Clamp(currentFOV, minFOV, maxFOV);

        virtualCamera.m_Lens.FieldOfView = currentFOV;
    }

    void CameraRotation(){

    }
}
