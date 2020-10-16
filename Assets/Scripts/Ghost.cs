using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float direction = 1;
    public static float speed = 1;

    private float yDirection = 1;
    private float dirChange = 2;
    private float nextDirChange;

    Animator mAnimator;
    
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAnimator.SetFloat("direction", direction);
        //FaceDirection();
    }
    
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
        //FaceDirection();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }

    public static void resetSpeed()
    {
        speed = 1;
    }

    private void FaceDirection()
    {
        Quaternion rotation3D = direction == -1 ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back); 
        transform.localRotation = rotation3D;
        //direction *= -1;
    }
}
