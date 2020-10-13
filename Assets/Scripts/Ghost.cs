using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    float direction = 1;
    [SerializeField]
    float speed = 1;

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

    void OnMouseDown()
    {
        Destroy(gameObject);

        // Increase score
        // Deduct bullet?
    } 

    void OnBecameInvisible()
    {
        Destroy(gameObject);

        // Laughing dog?
    }

    public void SetDirection(float direction)
    {
        this.direction = direction;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void FaceDirection()
    {
        Quaternion rotation3D = direction == -1 ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back); 
        transform.localRotation = rotation3D;
        //direction *= -1;
    }
}
