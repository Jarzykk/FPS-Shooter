using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class IdleTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_enemy.Player.IsAlive == false)
            NeedTransit = true;
    }
}
