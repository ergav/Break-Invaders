using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlatformMovement player;
    [SerializeField] float timeToRestart;
    float currentTimer;
    bool hasEventStarted;
    private void OnEnable()
    {
        player.OnPlatformDestroyed += StartCountdown;
    }
    private void Update()
    {
        RestartGame();
    }
    void StartCountdown()
    {
        hasEventStarted = true;
    }
    private void OnDisable()
    {
        player.OnPlatformDestroyed -= StartCountdown;
    }
    void RestartGame()
    {
        if (!hasEventStarted)
        {
            return;
        }
        currentTimer += Time.deltaTime;
        if(currentTimer >= timeToRestart)
        {
            SceneManager.LoadScene(3);
        }
    }
}
