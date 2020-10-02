using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject About;

    void Start() {
        MainMenuButton();
    }

    public void PlayNowButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void AboutButton() {
        MainMenu.SetActive(false);
        About.SetActive(true);
    }

    public void MainMenuButton() {
        MainMenu.SetActive(true);
        About.SetActive(false);
    }

    public void QuitButton() {
        Application.Quit();
    }
}