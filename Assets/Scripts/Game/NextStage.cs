using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene(sceneName: "Boss Battle");
        }
    }
}
