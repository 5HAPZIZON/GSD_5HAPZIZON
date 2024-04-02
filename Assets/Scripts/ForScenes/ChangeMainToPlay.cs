using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 메인 화면에서 게임 화면으로 넘어가는 스크립트

public class ChangeMainToPlay : MonoBehaviour
{


    public void MaintoFadeOut()
    {

        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        if(TimeUI.Wave == 1)
        {
            SceneManager.LoadScene("FirstDialogue");
        }
        else
        {
            SceneManager.LoadScene("ForProject");
        }
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
