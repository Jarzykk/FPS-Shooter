using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        Enabled();
    }

    protected virtual void Enabled()
    {
        NeedTransit = false;
    }
}