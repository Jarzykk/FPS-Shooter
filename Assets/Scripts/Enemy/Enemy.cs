using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyGroup _enemyGroup;
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private EnemyConditions _conditions;
    private Player _player;
    [SerializeField] private float _fieldOfView;
    [SerializeField] private float _sightDistance;
    [SerializeField] private Transform _eysPosition;
    [SerializeField] private Collider _collider;
    [SerializeField] private StateMachine _stateMachine;

    private float _attackDistance;
    private int _damage;
    private float _attackRate;

    public float AttackDistance => _attackDistance;
    public Player Player => _player;
    public Transform TargetsTranform => _player.transform;
    public float AttackRate => _attackRate;
    public float FieldOfView => _fieldOfView;
    public float SightDistance => _sightDistance;
    public Transform EysPosition => _eysPosition;
    public int Damage => _damage;
    public EnemyConditions EnemyConditions => _conditions;

    public event UnityAction Died;

    private void Awake()
    {
        _player = _enemyGroup.Player;
        SetValuesFromEnemyData();
    }

    private void OnEnable()
    {
        _conditions.Died += OnDeath;
    }

    private void OnDisable()
    {
        _conditions.Died -= OnDeath;
    }

    private void OnDeath()
    {
        _collider.enabled = false;
        _stateMachine.DisableStateMachine();
        Died?.Invoke();
    }

    private void SetValuesFromEnemyData()
    {
        _attackDistance = _enemyData.AttackDistance;
        _attackRate = _enemyData.AttackRate;
        _damage = _enemyData.Damage;
    }
}
