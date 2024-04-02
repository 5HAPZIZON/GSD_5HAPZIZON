using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSelectToMain : MonoBehaviour
{
    public void MaintoFadeOut()
    {

        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
