using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVisibility : MonoBehaviour
{
    public GameObject Play;
    public GameObject Settings;
    public GameObject Quit;
    public GameObject Music;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ButtonVisible");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ButtonVisible()
    {
        yield return new WaitForSeconds(4);
        Play.SetActive(true);
        Settings.SetActive(true);
        Quit.SetActive(true);
        yield return new WaitForSeconds(1);
        Music.SetActive(true);
    }
}
