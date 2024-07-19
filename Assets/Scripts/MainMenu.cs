using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Trillere Scene");
    }

    public void VisitUs()
    {
        Application.OpenURL("https://github.com/MoMakkawi/Cube-Game");
    }

    public void ResetGame()
    {
        StartCoroutine(ResetGameRoutine());
    }
    public void PlayGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    private IEnumerator ResetGameRoutine()
    {
        // Load the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Wait for the end of the frame to ensure the scene is loaded
        yield return new WaitForEndOfFrame();

        // Ensure time scale is reset
        Time.timeScale = 1;

        // Call the game manager reset function
        gameManager.ResetGameManager();
    }

    public void GameWin()
    {
        SceneManager.LoadScene("Game Win");
    }
}
