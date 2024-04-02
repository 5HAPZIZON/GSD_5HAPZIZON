using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForCastle : MonoBehaviour
{
    public float nowHp;
    public float castleHp;
    public Image hpBar;

    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    
    void Start()
    {
        //hpBar = GetComponent<Image>();
    }

    
    void Update()
    {
        hpBar.fillAmount = (float)nowHp / (float)castleHp;

        if(nowHp <= 0)
        {
            Panel.transform.SetAsLastSibling();
            StartCoroutine(FadeOut());
            StartCoroutine(Fail());
        }
    }

    IEnumerator Fail()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("FailScene");
    }

    IEnumerator FadeOut()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
    }

}
