using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;
    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame() 
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOver() 
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }
    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void QuitGame() 
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
