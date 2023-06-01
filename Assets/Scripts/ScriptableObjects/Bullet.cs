using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Weapon/Bullet", order = 51)]
public class Bullet : ScriptableObject
{
    [SerializeField] private string _name;

    public string Name => _name;
}
