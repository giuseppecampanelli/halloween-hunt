using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float timeStart = 60;
    public int level = 1;
    public int score = 0;
    public int enemiesRemaining = 10;

    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timer.text = Mathf.Round(timeStart).ToString();

        if (timeStart <= 0) {
            // game over
        }
    }
}
