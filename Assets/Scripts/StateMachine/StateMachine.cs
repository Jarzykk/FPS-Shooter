using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private float _delayBeforeStartFirstState = 0.3f;

    private State _current;

    public State CurrentState => _current;

    private void OnEnable()
    {
        StartCoroutine(StartMachineAfterDelay());
    }

    private void OnDisable()
    {
        DisableStateMachine();
    }

    private void Update()
    {
        if (_current == null)
            return;

        var nextState = _current.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State starttState)
    {
        _current = starttState;
        _current?.Enter();
    }

    public void DisableStateMachine()
    {
        _current.Exit();
        this.enabled = false;
    }

    private void Transit(State nextState)
    {
        _current?.Exit();
        _current = nextState;
        _current?.Enter();
    }

    private IEnumerator StartMachineAfterDelay()
    {
        float elapsedTime = 0;

        while (elapsedTime <= _delayBeforeStartFirstState)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Reset(_firstState);
    }
}