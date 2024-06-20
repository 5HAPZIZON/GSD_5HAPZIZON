using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{
    public string m_Timer = @"00:00";
    private bool m_IsPlaying;
    public float m_TotalSeconds = 3 * 60;
    public Text m_Text;

    public static int Wave = 1;
    public Text WaveText;

    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    private void Start()
    {

        m_Timer = CountdownTimer(true); // Text?? ???????? ???? ???? ????
        m_IsPlaying = !m_IsPlaying;
    }

    private void Update()
    {
        WaveText.text = Wave.ToString();
        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
        }

        // m_TotalSeconds?? ????????, ?????? 0?? ?????? ???? ??????  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
        }

        if (m_Text)
            m_Text.text = m_Timer;
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{1:00}:{2:00}", timespan.Hours, timespan.Minutes, timespan.Seconds);

        return timer;
    }

    private void SetZero()
    {
        Wave++;
        UIController.Money += 25;
        if(Wave == 6)
        {
            SceneManager.LoadScene("FinalDialogue");
        }
        else
        {
            SceneManager.LoadScene("ForProject");
        }
    }

    void Fade()
    {
        Panel.transform.SetAsLastSibling();
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
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
