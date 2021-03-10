using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    public GameObject Anim;
    public GameObject Text;
    public GameObject Menu;
    public GameObject White_End;
    public GameObject Crickets;
    public GameObject Explosion;
    public GameObject DoomEternal;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AnimationEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimationEnd()
    {
        yield return new WaitForSeconds(1.2f);
        Crickets.SetActive(false);
        Explosion.SetActive(true);
        yield return new WaitForSeconds(1);
        White_End.SetActive(true);
        yield return new WaitForSeconds(4);
        Anim.SetActive(false);
        Text.SetActive(true);
        Menu.SetActive(true);
        DoomEternal.SetActive(true);
    }
}
