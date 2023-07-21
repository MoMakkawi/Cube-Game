using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void VisitUs()
    {
        Application.OpenURL("https://github.com/MoMakkawi/Cube-Game");
    }
    public static void GameOver()
    {
        Bullet.EnemyDestroiedNumber = 0;
        SceneManager.LoadSceneAsync(2);
    }
    public static void GameWin()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
