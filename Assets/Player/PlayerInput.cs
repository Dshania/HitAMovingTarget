using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();


    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPos;
    }
    private void GetBodyMovement()
    {
        Vector2 movementVector2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector2.normalized);
    }
}
