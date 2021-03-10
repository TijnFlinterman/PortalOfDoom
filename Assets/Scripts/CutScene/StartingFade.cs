using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingFade : MonoBehaviour
{
    public GameObject StartImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.5f);
        StartImage.SetActive(false);
    }
}
