using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    private Camera _camera;
    [SerializeField] private int z;
    private void Awake()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
    public void FixedUpdate()
    {
        _camera.transform.position = this.transform.position + new Vector3(0, 0, z);
    }
}
