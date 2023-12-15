using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public bool canvasDisabled = false;

    private void Start() {
        canvasDisabled = false;
    }

    public void DisableCanvas()
    {
        canvas.gameObject.SetActive(false);
        canvasDisabled = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(1);

    }

    public void LoadNextLevel()
    {
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
