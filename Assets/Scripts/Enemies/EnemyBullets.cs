using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    Transform Target;
    Transform selfTransform;

    int bulletSpeed;

    Vector3 playerPosition;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 5;
        Target = GameObject.Find("Player").GetComponent<Transform>();
        playerPosition = Target.position;
        selfTransform = GetComponent<Transform>();
        direction = (playerPosition - selfTransform.position).normalized;
        transform.rotation = Target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position += direction * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
