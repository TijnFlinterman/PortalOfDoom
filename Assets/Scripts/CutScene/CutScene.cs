using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public Image Img1;
    public Image Img2;
    public Image Img3;

    public GameObject End;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Img3.transform.position.x > -3)
        {
            Img1.transform.Translate(-0.03f, 0, 0 * Time.deltaTime);
            Img2.transform.Translate(-0.03f, 0, 0 * Time.deltaTime);
            Img3.transform.Translate(-0.03f, 0, 0 * Time.deltaTime);
        }
        else
        {
            StartCoroutine("EndCutScene");
        }
    }

    IEnumerator EndCutScene()
    {
        Text.SetActive(false);
        End.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }
}
