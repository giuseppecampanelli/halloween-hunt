using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    Text scoreObject;

    private int score = 0;

    void Start()
    {
        Cursor.visible = false;

        scoreObject = GameObject.Find("Score").GetComponent<Text>();
        scoreObject.text = score.ToString();
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
