using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    /*[SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;*/
    [SerializeField] private SpriteRenderer characterRenderer;
    private PlayerController _controller;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }
    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotz) > 90f;
       /* armRenderer.flipY = Mathf.Abs(rotz) > 90f;
        armPivot.rotation = Quaternion.Euler(0, 0, rotz);*/
    }
}
