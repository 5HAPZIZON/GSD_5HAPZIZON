using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tutorial
{
    [TextArea]
    public string dialogue;

}


public class TutorialText : MonoBehaviour
{

    [SerializeField] private Text txt_Dialogue;
    private int count = 0;

    [SerializeField] private Tutorial[] tuto;



    void Start()
    {
        StartCoroutine(delayDialogue());
        
    }

    void Update()
    {
        
    }

    IEnumerator delayDialogue()
    {
        count++;
        if (count >= tuto.Length)
            count = 0;
        txt_Dialogue.text = tuto[count].dialogue;
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(delayDialogue());
    }

}
