using System.Collections;
using UnityEngine;

public class SceneScreens : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private LooseScreen _looseScreen;
    [SerializeField] private float _delayBeforeShowScreen = 3f;
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
        StartCoroutine(ShowScreenAfterDelay(_delayBeforeShowScreen, _winScreen));
    }

    private void EnableLooseScreen()
    {
        StartCoroutine(ShowScreenAfterDelay(_delayBeforeShowScreen, _looseScreen));
    }

    private IEnumerator ShowScreenAfterDelay(float delay, UIScreen screen)
    {
        float elapsedTime = 0;

        while(elapsedTime <= delay)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        screen.gameObject.SetActive(true);
    }
}
