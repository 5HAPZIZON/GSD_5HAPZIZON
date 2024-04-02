using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class FinalBackDialogue
{
    [TextArea]
    public string name;
    public string dialogue;
    public Sprite CG_left;
    public Sprite CG_right;
    public Sprite dialogueBox;

}


public class forFinalDialogue : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite_Left;
    [SerializeField] private SpriteRenderer sprite_Right;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;

    private bool isDialogue = false;

    private int count = 0;

    [SerializeField] private FinalBackDialogue[] FinalBackDialogue;
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

        txt_Dialogue.text = FinalBackDialogue[count].dialogue;
        txt_Name.text = FinalBackDialogue[count].name;
        sprite_Left.sprite = FinalBackDialogue[count].CG_left;
        sprite_Right.sprite = FinalBackDialogue[count].CG_right;
        sprite_DialogueBox.sprite = FinalBackDialogue[count].dialogueBox;
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
                if(count == 3 || count == 20)
                {
                    Fade();
                    middleFade();
                }
                if (count < FinalBackDialogue.Length)
                    NextDialogue();
                else
                    OnOff(false);
                if (count >= FinalBackDialogue.Length)
                {
                    //SceneManager.LoadScene("Credit");
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
        SceneManager.LoadScene("Credit");
    }

    public void middleFade()
    {
        StartCoroutine(middle());
    }

    private IEnumerator middle()
    {
        yield return new WaitForSecondsRealtime(3f);
        Panel.gameObject.SetActive(false);
    }
}