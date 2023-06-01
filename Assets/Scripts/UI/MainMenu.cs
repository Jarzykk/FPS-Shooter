using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private int _sceneIndexToLoad = 1;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
        _exitButton.onClick.RemoveListener(ExitGame);
    }

    private void Play()
    {
        SceneManager.LoadScene(_sceneIndexToLoad);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
