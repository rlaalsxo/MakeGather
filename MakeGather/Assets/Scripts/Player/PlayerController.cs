using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    //event�� �ܺο��� ȣ������ ���ϰ� �����ִ� ���
    protected virtual void Update()
    {
        HandleAttackDelay();
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 diretion)
    {
        OnLookEvent?.Invoke(diretion);
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > 0.2f)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
}
