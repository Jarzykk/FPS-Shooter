using UnityEngine.Events;

public class IdleState : State
{
    public event UnityAction BecameIdle;

    private void OnEnable()
    {
        BecameIdle?.Invoke();
    }
}
