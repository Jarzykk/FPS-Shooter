using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdleState : State
{
    public event UnityAction BecameIdle;

    private void OnEnable()
    {
        BecameIdle?.Invoke();
    }
}
