using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ForAnim
{
    [TextArea]
    public string dialogue;
    public string name;
    public Sprite background;
    public Sprite dialogueBox;
    //public bool isdialogue;

}


public class ForAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_BackGround;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Text txt_Name;

    public Image blackImg;
    public Image selectImg;
   // private bool isDialogue = false;


    private int count = 0;
    string blank;

    [SerializeField] private ForAnim[] anim;


    private void OnOff(bool flg)
    {
        sprite_DialogueBox.gameObject.SetActive(flg);
        //sprite_BackGround.gameObject.SetActive(flg);
        txt_Dialogue.gameObject.SetActive(flg);
        txt_Name.gameObject.SetActive(flg);
    }


    public void ShowDialogue()
    {
        count = 0;
        NextDialogue();
    }


    private void NextDialogue()
    {
        txt_Dialogue.text = anim[count].dialogue;
        txt_Name.text = anim[count].name;
        sprite_BackGround.sprite = anim[count].background;
        sprite_DialogueBox.sprite = anim[count].dialogueBox;
        //isDialogue = anim[count].isdialogue;
        if (txt_Dialogue.text == "Nothing")
        {
            OnOff(false);
            StartCoroutine("FadeIn");
        }
        else
        {
            OnOff(true);
        }
        count++;
    }

    void Start()
    {
        blackImg.gameObject.SetActive(false);
        selectImg.gameObject.SetActive(false);
        OnOff(true);
        ShowDialogue();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {

            if (count < anim.Length)
            {
                
                NextDialogue();
                
                
            }
            else
            {
                sprite_BackGround.gameObject.SetActive(false);
                OnOff(false);
                selectImg.gameObject.SetActive(true);
            }

            }
    }

    IEnumerator FadeIn()
    {
        for (int i=0; i<10; i++)
        {
            float f = i / 8.0f;
            Color c = sprite_BackGround.material.color;
            c.a = f;
            sprite_BackGround.color = c;
            yield return new WaitForSeconds(0.05f);

        }
    }

   

}
