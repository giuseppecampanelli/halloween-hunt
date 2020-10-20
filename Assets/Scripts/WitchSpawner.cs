using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSpawner : MonoBehaviour
{
    public GameObject enemy;

    private static float spawnRate;
    private static float nextSpawn;

    void Start()
    {
        spawnRate = Random.Range(10.0f, 25.0f);
        nextSpawn = Random.Range(10.0f, 25.0f);
    }
    
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

            spawnRate = Random.Range(10.0f, 25.0f);
        }
    }

    public static void resetTimer()
    {
        nextSpawn = 0;
        spawnRate = Random.Range(10.0f, 25.0f);
    }
}
