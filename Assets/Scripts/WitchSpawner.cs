using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSpawner : MonoBehaviour
{
    public static float spawnRate = 3;
    
    public GameObject enemy;

    private static float nextSpawn = 0;
    
    void Update()
    {
        if (Time.time > nextSpawn && !Game.gameOver) {
            nextSpawn = Time.time + spawnRate;

            float randY = Random.Range(-4.5f, 4.5f);

            float direction = 1;
            if (Random.Range(1.0f, 2.0f) >= 1.5f) {
                direction = -1;
            }

            Vector2 spawnLocation = new Vector2(direction * -10, randY);

            GameObject witchObject = Instantiate(enemy, spawnLocation, Quaternion.identity);
            witchObject.GetComponent<Witch>().SetDirection(direction);
        }
    }

    public static void resetTimer()
    {
        nextSpawn = 0;
    }
}
