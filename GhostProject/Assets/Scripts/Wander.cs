using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour
{
    int speed = 1;
    Vector2 direction;
    Rigidbody2D rigidbody;

    void randomDirection()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        randomDirection();
    }

    void Update()
    {
        rigidbody.AddForce(direction*speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        randomDirection();
    }
}