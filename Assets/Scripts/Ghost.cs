using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private float direction = 1;

    [SerializeField] private float speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(direction * speed * Time.deltaTime, 0));
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
