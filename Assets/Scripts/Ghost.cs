using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float direction = 1;
    public static float speed = 1;

    Animator mAnimator;
    
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAnimator.SetFloat("direction", direction);
        //FaceDirection();
    }
    
    void Update()
    {
        transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
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
