using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneScreens : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private LooseScreen _looseScreen;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private void OnEnable()
    {
        _importantSceneObjects.LevelConditions.PlayerWon += EnableWinScreen;
        _importantSceneObjects.LevelConditions.PlayerLoose += EnableLooseScreen;
    }

    private void OnDisable()
    {
        _importantSceneObjects.LevelConditions.PlayerWon -= EnableWinScreen;
        _importantSceneObjects.LevelConditions.PlayerLoose -= EnableLooseScreen;
    }

    private void Start()
    {
        DisableScreens();
    }

    private void DisableScreens()
    {
        _winScreen.gameObject.SetActive(false);
        _looseScreen.gameObject.SetActive(false);
    }

    private void EnableWinScreen()
    {
        _winScreen.gameObject.SetActive(true);
    }

    private void EnableLooseScreen()
    {
        _looseScreen.gameObject.SetActive(true);
    }
}
