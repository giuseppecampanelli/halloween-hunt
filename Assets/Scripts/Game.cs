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
    
    void Start()
    {
        timer.text = timeRemaining.ToString();
        score.text = scoreValue.ToString();
        level.text = levelValue.ToString();
    }
    
    void Update()
    {

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            timer.text = Mathf.Round(timeRemaining).ToString();
            score.text = scoreValue.ToString();
            level.text = levelValue.ToString();

            if (enemiesRemaining == 0) {
                ClearEnemies();

                levelValue++;
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
            // game over
            gameOver = true;
            ClearEnemies();
        }
    }

    private void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
