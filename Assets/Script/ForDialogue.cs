using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEditor;


[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string name;
    public string dialogue;
    public Sprite CG_left;
    public Sprite CG_right;

}


public class ForDialogue : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite_Left;
    [SerializeField] private SpriteRenderer sprite_Right;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;


    private bool isDialogue = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;


    private void OnOff(bool flg)
    {
        sprite_DialogueBox.gameObject.SetActive(flg);
        sprite_Right.gameObject.SetActive(flg);
        sprite_Left.gameObject.SetActive(flg);
        txt_Dialogue.gameObject.SetActive(flg);
        txt_Name.gameObject.SetActive(flg);
        isDialogue = flg;
    }

    
    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        NextDialogue();
    }


    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_Name.text = dialogue[count].name;
        sprite_Left.sprite = dialogue[count].CG_left;
        sprite_Right.sprite = dialogue[count].CG_right;
        count++;
    }

    void Start()
    {
        ShowDialogue();
    }


    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (count < dialogue.Length)
                    NextDialogue();
                else
                {
                    OnOff(false);
                }
                if (count >= dialogue.Length)
                {
                    //SceneManager.LoadScene("MainGame");
                    Fade();
                    waitForLoad();
                }
            }
        }
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
        SceneManager.LoadScene("MainGame");
    }
}

