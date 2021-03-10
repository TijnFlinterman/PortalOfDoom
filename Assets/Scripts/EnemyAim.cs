using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private GameObject head;

    void Start()
    {
        head = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(
           head.transform.position.x - transform.position.x,
           head.transform.position.y - transform.position.y
       );

        transform.up = direction;
    }
}
