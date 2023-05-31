using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class IdleTransition : Transition
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Enemy>().Player;
    }

    private void Update()
    {
        if (_player.IsAlive == false)
            NeedTransit = true;
    }
}
