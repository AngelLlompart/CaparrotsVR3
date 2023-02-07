using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        if(EditorApplication.isPlaying) 
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#else
            Application.Quit();
#endif
    }
}
