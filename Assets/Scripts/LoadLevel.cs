using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public bool vsAI;

    public void LoadTheLevel (string theLevel)
    {
        SceneManager.LoadScene(theLevel);
        if (vsAI)
        {
            GameManager.isAI = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
