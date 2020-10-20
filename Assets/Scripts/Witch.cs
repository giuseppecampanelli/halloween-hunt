using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public float direction = 1;
    public static float speed = 1;
    public static int points = 10;
    public int health = 3;

    private float yDirection = 1;
    private float dirChange = 2;
    private float nextDirChange;
    
    void Update()
    {
        if (Time.time > nextDirChange) {
            yDirection = Random.Range(0.0f, 1.0f) >= 0.5f ? 1 : -1;
            nextDirChange += dirChange;
        }

        float yTranslation = Mathf.Sin(Time.time) * 0.005f * yDirection;

        if (transform.position.y + yTranslation > 5 || transform.position.y + yTranslation < -5)
            yDirection *= -1;

        transform.Translate(new Vector2(direction * speed * Time.deltaTime, yTranslation));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;

        if (direction == -1) {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    public static void resetSpeed()
    {
        speed = 1;
    }

    private void FlipSprite()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
