using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCharacter : MonoBehaviour
{
    public void SetDog()
    {
        ForData.forData.forMainCharacter = 1;
    }

    public void SetCat()
    {
        ForData.forData.forMainCharacter = 2;
    }

    public void SceneLoad()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
