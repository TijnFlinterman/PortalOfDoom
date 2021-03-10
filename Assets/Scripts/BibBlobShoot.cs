using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibBlobShoot : MonoBehaviour
{
    public GameObject EBulletPrefab;
    public AudioSource Eshot;
    public int delay = 80;
    private GameObject head;

    void FixedUpdate()
    {
        head = GameObject.Find("Player");
        delay -= 1;
        int ran = Random.Range(1, 100);

        Vector2 direction = new Vector2(
           head.transform.position.x - transform.position.x,
           head.transform.position.y - transform.position.y
           );

        transform.up = direction;

        if (ran == 1)
        {

            Instantiate(EBulletPrefab, transform.position, transform.rotation);
            Eshot.Play();
        }
        if (delay == 0)
        {
            Instantiate(EBulletPrefab, transform.position, transform.rotation);
            Eshot.Play();
            delay = 80;
        }
    }
}
