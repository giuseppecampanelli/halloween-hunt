using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject MainMenu;

    public void NormalMode() {
        PlayerPrefs.SetInt("GameMode", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void SpecialMode() {
        PlayerPrefs.SetInt("GameMode", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Quit() {
        Application.Quit();
    }
}