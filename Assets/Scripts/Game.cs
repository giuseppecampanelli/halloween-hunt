using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static int scoreValue = 0;
    public static float timeRemaining = 60;
    public static int levelValue = 1;
    public static int enemiesRemaining = 5;
    public static bool gameOver;

    public Text timer;
    public Text score;
    public Text level;
    public Text gameOverText;

    public AudioSource levelUpAudio;
    public AudioSource timeWarningAudio;
    public AudioSource gameOverAudio;

    public GameObject pumpkin;

    private float warningRate = 1;
    private float nextWarning = 0;
    
    void Start()
    {
        timer.text = timeRemaining.ToString();
        score.text = scoreValue.ToString();
        level.text = levelValue.ToString();
        gameOverText.enabled = false;
        pumpkin.SetActive(false);

        int mode = PlayerPrefs.GetInt("GameMode");

        // GameMode Special: Update points & enable continuous shooting
        if (mode == 1) {
            Ghost.points = 1;
            Crosshair.miss = 2;
            GhostSpawner.spawnRate = 1;
            Crosshair.continuousShooting = true;
        }
    }
    
    void Update()
    {

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            timer.text = Mathf.Round(timeRemaining).ToString();
            score.text = scoreValue.ToString();
            level.text = levelValue.ToString();

            if (Time.time > nextWarning && timeRemaining <= 5) {
                nextWarning = Time.time + warningRate;
                timeWarningAudio.Play(0);
            }

            if (enemiesRemaining == 0) {
                ClearEnemies();

                levelValue++;
                levelUpAudio.Play(0);

                enemiesRemaining = 5;
                timeRemaining = 60;

                Ghost.speed *= 1.05f;

                GhostSpawner.resetTimer();

                if (levelValue == 100) {
                    levelValue = 1;
                    Ghost.resetSpeed();
                }
            }
        } else {
            if (!gameOver) {
                gameOverAudio.Play(0);
                pumpkin.SetActive(true);
            }

            gameOver = true;
            gameOverText.enabled = true;
            ClearEnemies();
        }
    }

    private void ClearEnemies()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in ghosts) {
            Destroy(ghost);
        }

        GameObject[] witches = GameObject.FindGameObjectsWithTag("Witch");
        foreach (GameObject witch in witches) {
            Destroy(witch);
        }
    }
}
