using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{


    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StopCoroutine(Delay());
            Fade();
            waitForLoad();

        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(Delay());
    }

    public void Fade()
    {
        Panel.transform.SetAsLastSibling();
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
    }

    public void waitForLoad()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        Application.Quit();
    }
}
