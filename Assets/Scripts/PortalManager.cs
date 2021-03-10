using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public Animator anim;
    public GameObject bossPrefab;
    public Transform bossPos;

    int currentHP;
    bool vulnerability;
    bool hasEntered;
    bool bossdied;
    bool hasEnd;
    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        currentHP = 5;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (hasEntered == false)
        {
            if (coll.gameObject.tag == ("Player"))
            {
                StartCoroutine("Beginning");
                hasEntered = true;
            }
        }

    }
    IEnumerator Beginning()
    {
        anim.SetBool("playerEnter", true);
        yield return new WaitForSeconds(5);
        Instantiate(bossPrefab, bossPos.position, bossPos.rotation);
        anim.SetBool("bossSpawndone", true);
    }
    public void BossDeath()
    {
        bossdied = true;
    }
    public void Update()
    {
        if (bossdied == true)
        {
            vulnerability = true;
        }
        if (currentHP <= 0)
        {
            anim.SetBool("portalBroken", true);
            if (hasEnd == false)
            {
                hasEnd = true;
                StartCoroutine("end");
            }
        }
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName: "Victory");
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (vulnerability == true)
        {

            if (collision.gameObject.tag == "Bullet")
            {
                currentHP--;
                Destroy(collision.gameObject);
            }
        }
    }
}
