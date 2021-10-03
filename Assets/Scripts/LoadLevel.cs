using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private bool vsAI;

    public void LoadTheLevel (string theLevel)
    {
        GameManager.isAI = vsAI;
        GameManager.canDisco = false;

        SceneManager.LoadScene(theLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
