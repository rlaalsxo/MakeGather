using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private Animator animator;
    private void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        animator.runtimeAnimatorController = StartManager.instance.playerAnimator.Where(name=> name.name == StartManager.instance.character.name).FirstOrDefault();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
    private void Move(Vector2 direction)
    {
        animator.SetTrigger("Walk");
        _movementDirection = direction;
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5f;
        _rigidbody.velocity = direction;
    }
}
