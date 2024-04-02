using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonToStartGame : MonoBehaviour
{
    public Image Panel;
    public Canvas dialouge;
    float time = 0f;
    float F_time = 1f;

    public void Fade()
    {
        Panel.gameObject.SetActive(true);
        Panel.transform.SetAsLastSibling();
        StartCoroutine(FadeFlow());
    }


    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
    }

    public void LoadScene()
    {
        if (TimeUI.Wave == 5)
        {
            SceneManager.LoadScene("FinalEnemyDialogue");
        }
        StartCoroutine(wait());
    }

    public void ForMenu()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("MainGame");

    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("MainMenu");
    }

    public void turnOff()
    {
        dialouge.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
