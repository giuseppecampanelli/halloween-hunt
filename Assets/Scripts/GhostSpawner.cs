using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    public float spawnRate = 3;
    [SerializeField]
    public GameObject enemy;

    float nextSpawn = 0.0f;
    
    void Start()
    {

    }
    
    void Update()
    {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;

            float randY = Random.Range(-4.5f, 4.5f);

            float direction = 1;
            if (Random.Range(1, 3) == 1) {
                direction = -1;
            }

            Vector2 spawnLocation = new Vector2(direction * -11, randY);

            GameObject ghostObject = Instantiate(enemy, spawnLocation, Quaternion.identity);
            ghostObject.GetComponent<Ghost>().SetDirection(direction);
        }
    }
}
