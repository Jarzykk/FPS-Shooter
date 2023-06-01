using TMPro;
using UnityEngine;

[DefaultExecutionOrder(2)]
public class AmmoBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerAmmoAmount;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private void OnEnable()
    {
        _importantSceneObjects.Player.AmmoAmountChanged += UpdateAmmoAmount;
        _importantSceneObjects.Player.WeaponChanged += UpdateAmmoAmount;
    }

    private void OnDisable()
    {
        _importantSceneObjects.Player.AmmoAmountChanged -= UpdateAmmoAmount;
        _importantSceneObjects.Player.WeaponChanged -= UpdateAmmoAmount;
    }

    private void UpdateAmmoAmount()
    {
        _playerAmmoAmount.text = _importantSceneObjects.Player.CurrentWeaponAmmoAmount.ToString();
    }
}
