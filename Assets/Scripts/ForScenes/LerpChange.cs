using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpChange : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    public void Fade()
    {
        Panel.transform.SetAsLastSibling();
        StartCoroutine(FadeFlow());
    }


    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a > 0)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
    }

   
    public void WaitForStart()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
    }

    void Start()
    {
        Fade();
        WaitForStart();
    }

    void Update()
    {
        if(Panel.color.a == 0)
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
