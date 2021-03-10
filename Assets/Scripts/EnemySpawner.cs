using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    bool bB;
    bool sB;
    bool wF;
    bool dM;

    public GameObject bBprefab;
    public GameObject sBprefab;
    public GameObject wFprefab;
    public GameObject dMprefab;

    void Start()
    {
        if (tag == ("BigBlobSpawn"))
        {
            bB = true;
        }
        else { bB = false; }

        if (tag == ("SmallBlobSpawn"))
        {
            sB = true;
        }
        else { sB = false; }

        if (tag == ("WolfSpawn"))
        {
            wF = true;
        }
        else { wF = false; }

        if (tag == ("DemonSpawn"))
        {
            dM = true;
        }
        else { dM = false; }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (bB == true && coll.gameObject.tag == ("Player"))
        {
            Instantiate(bBprefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (sB == true && coll.gameObject.tag == ("Player"))
        {
            Instantiate(sBprefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (wF == true && coll.gameObject.tag == ("Player"))
        {
            Instantiate(wFprefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (dM == true && coll.gameObject.tag == ("Player"))
        {
            Instantiate(dMprefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
