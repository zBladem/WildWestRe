using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    bool isLevelCompleted;
    public GameObject gameOverScreen;
    public GameObject player;


    public static event Action OnReset;
    public static event Action Completed;

    void Start()
    {
        isLevelCompleted = false;
        PlayerHealth.PlayerHasDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }

    void OnDestroy()
    {
        PlayerHealth.PlayerHasDied -= GameOverScreen;
    }  

    public void Change()
    {
        isLevelCompleted = true;
        Completed?.Invoke();
        SceneManager.LoadScene(sceneName);
    } 
    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        OnReset?.Invoke();
        gameOverScreen.SetActive(false);
        ReloadLevel();  
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
