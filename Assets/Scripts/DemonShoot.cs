using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShoot : MonoBehaviour
{
    public GameObject EBulletPrefab;
    public AudioSource Eshot;
    public int delay = 80;

    void FixedUpdate()
    {
        delay -= 1;

        if (delay == 0)
        {
            Instantiate(EBulletPrefab, transform.position, transform.rotation);
            Eshot.Play();
            delay = 80;
        }
    
    }
}
