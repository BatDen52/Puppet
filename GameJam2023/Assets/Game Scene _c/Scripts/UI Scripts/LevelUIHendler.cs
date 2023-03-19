using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIHendler : MonoBehaviour
{
    public void ReturnToMenu()
    {
        LoadScene(0);
    }

    public void RestartLevel()
    {
        LoadScene(1);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
