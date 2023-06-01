using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private int _playerWonAmount;
    private int _playerLooseAmount;
    private const string _saveKey = "PlayerScore";

    private void OnEnable()
    {
        _importantSceneObjects.LevelConditions.PlayerWon += OnPlayerWon;
        _importantSceneObjects.LevelConditions.PlayerLoose += OnPlayerLoose;
    }

    private void OnDisable()
    {
        _importantSceneObjects.LevelConditions.PlayerWon -= OnPlayerWon;
        _importantSceneObjects.LevelConditions.PlayerLoose -= OnPlayerLoose;
    }

    private void Start()
    {
        Load();
        //Save();
    }

    private void OnPlayerWon()
    {
        _playerWonAmount++;

        Save();
    }

    private void OnPlayerLoose()
    {
        _playerLooseAmount++;

        Save();
    }

    private void Load()
    {
        var loadedData = SaveSystem.Load<PlayerScoreSaveData>(_saveKey);

        _playerWonAmount = loadedData.PlayerWonAmount;
        _playerLooseAmount = loadedData.PlayerLooseAmount;
    }

    private void Save()
    {
        SaveSystem.Save(_saveKey, CreateSaveSnapshot());
    }

    private PlayerScoreSaveData CreateSaveSnapshot()
    {
        return new PlayerScoreSaveData()
        {
            PlayerWonAmount = _playerWonAmount,
            PlayerLooseAmount = _playerLooseAmount
        };
    }
}
