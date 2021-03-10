using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float bulletSpeed = 0.4f;

    void FixedUpdate()
    {
        transform.Translate(0, bulletSpeed, 0);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == ("Wall"))
        {
            Destroy(gameObject);
        }
    }
}