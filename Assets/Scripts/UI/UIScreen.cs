using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(3)]
public abstract class UIScreen : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;
    [SerializeField] private TMP_Text _winScore;
    [SerializeField] private TMP_Text _looseScore;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartScene);
        _exitButton.onClick.AddListener(ExitGame);

        _importantSceneObjects.PlayerScore.ScoreUpdated += SetScore;

        SetScore();
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartScene);
        _exitButton.onClick.RemoveListener(ExitGame);

        _importantSceneObjects.PlayerScore.ScoreUpdated += SetScore;
    }

    private void SetScore()
    {
        _winScore.text = $"Win score: {_importantSceneObjects.PlayerScore.PlayerWonAmount}";
        _looseScore.text = $"Loose score: {_importantSceneObjects.PlayerScore.PlayerLooseAmount}";
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
