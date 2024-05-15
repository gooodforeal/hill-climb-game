using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LoadGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
    public void SettingsGame() {
        SceneManager.LoadSceneAsync(2);
    }
}
