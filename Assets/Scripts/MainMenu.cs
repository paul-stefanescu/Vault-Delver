using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes");
    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
