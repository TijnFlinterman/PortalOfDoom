using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieControl : MonoBehaviour
{

    public float speed;
    public Transform target;
    public int HP;

    public Rigidbody2D rb;

    bool faceRight;

    float x;
    float y;

    Vector3 position;

    void Start()
    {
        faceRight = false;

        target = target.GetComponent<Transform>();
        position = transform.position;
    }

    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;

        if (Vector2.Distance(transform.position, target.position) > 1.25)
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position.x > x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            faceRight = true;
        }
        else if (transform.position.x < x && faceRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            faceRight = false;
        }
    }
}
